using ROAPI.Application.Character.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROAPI.Application.Character.Interfaces
{
    public interface ICharacterService
    {
        Task<List<CharacterDto>> GetCharsByAccountId(int accountId, int page = 1, int pageSize = 10);
        Task<List<CharacterDto>> GetCharsByAccountId(int accountId);
        Task<List<CharacterDto>> GetChars(int page = 1, int pageSize = 10);
        Task<List<CharacterDto>> GetChars();
        Task<CharacterDto> GetChar(int charId);
    }
}
