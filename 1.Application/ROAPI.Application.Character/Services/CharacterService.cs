using ROAPI.Application.Character.Interfaces;
using ROAPI.Domain.Character.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ROAPI.Application.Character.Dtos;
using ROAPI.Data.Data.Extensions;

namespace ROAPI.Application.Character.Services
{
    public class CharacterService: ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<List<CharacterDto>> GetCharsByAccountId(int accountId, int page = 1, int pageSize = 10)
        {
            var debug = _characterRepository.GetAll().Where(c => c.account_id == accountId).ToSql();
            var characters = await _characterRepository.GetAll().Where(c => c.account_id == accountId).ToListAsync();//.Paged(page, pageSize).ToListAsync();
            return _mapper.Map<List<CharacterDto>>(characters);
        }
        public async Task<List<CharacterDto>> GetCharsByAccountId(int accountId)
        {
            var characters = await _characterRepository.GetAll().Where(c => c.account_id == accountId).ToListAsync();
            return _mapper.Map<List<CharacterDto>>(characters);
        }
        public async Task<List<CharacterDto>> GetChars(int page = 1, int pageSize = 10)
        {
            var characters = await _characterRepository.GetAll().Paged(page, pageSize).ToListAsync();
            return _mapper.Map<List<CharacterDto>>(characters);
        }
        public async Task<List<CharacterDto>> GetChars()
        {
            var characters = await _characterRepository.GetAll().ToListAsync();
            return _mapper.Map<List<CharacterDto>>(characters);
        }
        public async Task<CharacterDto> GetChar(int charId)
        {
            var character = await _characterRepository.GetById(charId);
            return _mapper.Map<CharacterDto>(character);
        }
    }
}
