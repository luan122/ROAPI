using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROAPI.Api.Models.Character;
using ROAPI.Application.Character.Interfaces;

namespace ROAPI.Api.Controllers.Characters
{
    //[Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet("getcharbyaccountid/{:accountId}")]
        public async Task<ActionResult<CharacterModel>> GetByAccountId([FromBody]int accountId)
        {
            return Ok();
        }
        [HttpGet("getcharbyid/{:id}")]
        public async Task<ActionResult<CharacterModel>> GetByCharId([FromBody]int charId)
        {
            return Ok();
        }
        [HttpGet("GetChars")]
        public async Task<ActionResult<List<CharacterModel>>> GetChars()
        {
            /*var identity = HttpContext.User.Identity as ClaimsIdentity;
            int accountId;
            int.TryParse(identity.Claims.Where(s => s.Type.ToLower() == "accountid").FirstOrDefault()?.Value, out accountId);
            if (accountId == 0)
                return NotFound();*/
            var characters = await _characterService.GetCharsByAccountId(2000000, 1, 10);
            return Ok(_mapper.Map<List<CharacterModel>>(characters));
        }
        [HttpGet("GetList")]
        [Authorize(Roles = "99")]
        public async Task<ActionResult<List<CharacterModel>>> GetList()
        {
            return Ok();
        }
    }
}