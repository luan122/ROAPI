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
using Microsoft.AspNetCore.JsonPatch;
using ROAPI.Data.Data.Entities.Character;

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
            var characters = await _characterRepository.GetAll().Where(c => c.account_id == accountId).Paged(page, pageSize).ToListAsync();
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
            var character = await _characterRepository.GetByIdNoTracking(charId);
            return _mapper.Map<CharacterDto>(character);
        }
        public async Task<CharacterDto> Updatecharacter(CharacterDto dto)
        {
            var entity = _characterRepository.Update(_mapper.Map<CharacterEntity>(dto));
            var update = await _characterRepository.SaveChanges();
            if (update > 0)
                return _mapper.Map<CharacterDto>(entity);
            else
                return null;
        }
    }
}
