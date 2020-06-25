using ROAPI.Data.Data.Entities.Character;
using ROAPI.Domain.Character.Contracts.Repositories;
using ROAPI.Infrastructure.Data.Data.Contexts;
using ROAPI.Infrastructure.Data.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ROAPI.Domain.Character.Repositories
{
    public class CharacterRepository:BaseRepository<CharacterEntity, MainDbContext>, ICharacterRepository
    {
        public CharacterRepository(MainDbContext context) : base(context) { }
        public async Task<CharacterEntity> GetByIdNoTracking(int id)
        {
            return await DbSet.AsNoTracking().Where(c => c.char_id == id).FirstOrDefaultAsync();
        }
    }
}
