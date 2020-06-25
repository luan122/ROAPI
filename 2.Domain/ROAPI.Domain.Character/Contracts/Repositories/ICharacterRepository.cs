using ROAPI.Data.Data.Entities.Character;
using ROAPI.Infrastructure.Data.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROAPI.Domain.Character.Contracts.Repositories
{
    public interface ICharacterRepository:IBaseRepository<CharacterEntity>
    {
        Task<CharacterEntity> GetByIdNoTracking(int id);
    }
}
