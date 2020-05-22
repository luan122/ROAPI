using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ROAPI.Api.Configurations;
using ROAPI.Api.Models.Account;
using ROAPI.Application.Account.Dtos;
using ROAPI.Application.Account.Interfaces.Services;
using ROAPI.Application.Common.Contracts.Services;
using ROAPI.Data.Data.Entities.Configurations;
using ROAPI.Application.Common.Utils;
using ROAPI.Api.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ROAPI.Api.Enums;
using Pomelo.Extensions.Caching.MySql;

namespace ROAPI.Api.Controllers.Account
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IAccountService _accountService;
        private readonly RagnarokConfiguration _ragnarokConfigurations;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(ILoginService loginService, IMapper mapper, IConfigurationService configurationService, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _loginService = loginService;
            _accountService = accountService;
            _mapper = mapper;
            _ragnarokConfigurations = configurationService.GetRagnarokConfigurations();
            _httpContextAccessor = httpContextAccessor;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(AccountModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<AccountModel>> Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var result = await _accountService.GetAccountInformation(identity.Claims.Where(s => s.Type.ToLower() == "user").FirstOrDefault()?.Value, Convert.ToInt32(identity.Claims.Where(s => s.Type.ToLower().Contains("role")).FirstOrDefault()?.Value));
            var model = _mapper.Map<AccountModel>(result);
            if(model != null)
                return Ok(model);
            return NotFound();

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(AccessTokenModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<AccessTokenModel>> Login(
            [FromBody] LoginModel user,
            [FromServices]SigningConfiguration signingConfigurations,
            [FromServices]TokenConfiguration tokenConfigurations,
            [FromServices]IDistributedCache cache)
        {
            bool validCredentials = false;
            if (user.GrantType == GrantTypeEnum.Password)
            {
                validCredentials = _loginService.ValidateLogin(_mapper.Map<LoginDto>(user));
            }
            else if (user.GrantType == GrantTypeEnum.RefreshToken)
            {
                if (!String.IsNullOrWhiteSpace(user.RefreshToken))
                {
                    RefreshTokenModel refreshTokenBase = null;

                    string strTokenArmazenado =
                        cache.GetString(user.RefreshToken);
                    if (!String.IsNullOrWhiteSpace(strTokenArmazenado))
                    {
                        refreshTokenBase = JsonConvert
                            .DeserializeObject<RefreshTokenModel>(strTokenArmazenado);
                    }

                    validCredentials = (refreshTokenBase != null &&
                        user.Login == refreshTokenBase.Login &&
                        user.RefreshToken == refreshTokenBase.RefreshToken);

                    // Elimina o token de refresh já que um novo será gerado
                    if (validCredentials)
                        cache.Remove(user.RefreshToken);
                }
            }
            if (validCredentials)
            {
                return Ok(await GenerateToken(user.Login, signingConfigurations, tokenConfigurations, cache));
            }
            else
            {
                var response = new AccessTokenModel()
                {
                    Authenticated = false,
                    Message = "Failed to attempt login"
                };
                var bad = new BadRequestObjectResult(response);
                return bad;
                
                
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var result = await _accountService.AddAccount(_mapper.Map<AccountDto>(model),_httpContextAccessor);
            if (result)
                return CreatedAtAction(nameof(Get),true);
            return BadRequest();
        }
        #region Token logic, needs to be here because the organization of projects (needs to verify)
        private async Task<AccessTokenModel> GenerateToken(
           string login,
           SigningConfiguration signingConfigurations,
           TokenConfiguration tokenConfigurations,
           IDistributedCache cache)
        {
            var account = await _accountService.GetAccountInformation(login);
            ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(login, "Login"),
                        new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("user", login),
                        new Claim(ClaimTypes.Role, account.group_id.ToString())
                        }
                    );

            DateTime creationDate = DateTime.Now;
            DateTime expirationDate = creationDate +
                TimeSpan.FromSeconds(tokenConfigurations.TokenExpiration);
            TimeSpan finalExpiration =
                TimeSpan.FromSeconds(tokenConfigurations.RefreshTokenExpiration);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = creationDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);

            var result = new AccessTokenModel()
            {
                Authenticated = true,
                Created = creationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                RefreshToken = RefreshToken.Generate(),
                Message = "OK"
            };
            var refreshTokenData = new RefreshTokenModel();
            refreshTokenData.RefreshToken = result.RefreshToken;
            refreshTokenData.Login = login;

            DistributedCacheEntryOptions cacheOptions =
                new DistributedCacheEntryOptions();
            cacheOptions.SetAbsoluteExpiration(finalExpiration);
            await cache.SetStringAsync(result.RefreshToken,
                JsonConvert.SerializeObject(refreshTokenData),
                cacheOptions);
            return result;
        }
        #endregion
    }
}