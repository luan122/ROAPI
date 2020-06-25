using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ROAPI.Api.Models.Character;
using ROAPI.Application.Character.Dtos;
using ROAPI.Application.Character.Interfaces;

namespace ROAPI.Api.Controllers.Characters
{
    [Authorize("Bearer")]
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
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<CharacterModel>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(Nullable))]
        [HttpGet("Getcharbyaccountid/{accountId}")]
        [Authorize(Roles = "99")]
        public async Task<ActionResult<List<CharacterModel>>> GetByAccountId([FromBody]int accountId)
        {
            var characters = await _characterService.GetCharsByAccountId(accountId);
            if (characters != null)
                return Ok(_mapper.Map<List<CharacterModel>>(characters));
            else
                return NotFound();
        }
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(CharacterModel))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(Nullable))]
        [HttpGet("Getcharbyid/{id}")]
        public async Task<ActionResult<CharacterModel>> GetByCharId([FromBody]int charId)
        {
            var character = await _characterService.GetChar(charId);
            if (character != null)
                return Ok(_mapper.Map<CharacterModel>(character));
            else
                return NotFound();
        }
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<CharacterModel>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(Nullable))]
        [HttpGet("GetChars")]
        public async Task<ActionResult<List<CharacterModel>>> GetChars(bool paged = false, int page = 1, int pageSize = 10)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int accountId;
            int.TryParse(identity.Claims.Where(s => s.Type.ToLower() == "accountid").FirstOrDefault()?.Value, out accountId);
            if (accountId == 0)
                return NotFound();
            var characters = paged?
                await _characterService.GetCharsByAccountId(accountId, page, pageSize) :
                await _characterService.GetCharsByAccountId(accountId);

            return Ok(_mapper.Map<List<CharacterModel>>(characters));
        }
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<CharacterModel>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, type: typeof(Nullable))]
        [HttpGet("GetList")]
        [Authorize(Roles = "99")]
        public async Task<ActionResult<List<CharacterModel>>> GetList(bool paged = false, int page = 1, int pageSize = 10)
        {
            var characters = paged ?
                await _characterService.GetChars(page, pageSize) :
                await _characterService.GetChars();
            if (characters != null)
                return Ok(_mapper.Map<List<CharacterModel>>(characters));
            else
                return NotFound();
        }
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(CharacterModel))]
        [ProducesResponseType(statusCode: StatusCodes.Status304NotModified)]
        [HttpPatch("Edit/{characterId}")]
        public async Task<ActionResult<CharacterModel>> Patch(int characterId, [FromBody]JsonPatchDocument<CharacterModel> model)
        {
            
            var actualDto = await _characterService.GetChar(characterId);
            if(actualDto == null && actualDto.charId != characterId)
                return new StatusCodeResult(304);
            var actualModel = _mapper.Map<CharacterModel>(actualDto);
            model.ApplyTo(actualModel);
            var result = await _characterService.Updatecharacter(_mapper.Map<CharacterDto>(actualModel));
            if(result == null)
                return new StatusCodeResult(304);
            return Ok(_mapper.Map<CharacterModel>(result));

        }
    }
}