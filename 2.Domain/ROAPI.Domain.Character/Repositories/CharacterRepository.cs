using ROAPI.Data.Data.Entities.Character;
using ROAPI.Domain.Character.Contracts.Repositories;
using ROAPI.Infrastructure.Data.Data.Contexts;
using ROAPI.Infrastructure.Data.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROAPI.Domain.Character.Repositories
{
    public class CharacterRepository:BaseRepository<CharacterEntity, MainDbContext>, ICharacterRepository
    {
        public CharacterRepository(MainDbContext context) : base(context) { }
    }
}
