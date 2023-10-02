using MagicHouse_HouseAPI.Data;
using MagicHouse_HouseAPI.Models;
using MagicHouse_HouseAPI.Repository.IRepository;
using MagicT_TAPI.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MagicHouse_HouseAPI.Repository
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        private readonly ApplicationDBContext _db;
        public HouseRepository(ApplicationDBContext db): base(db)
        {
            _db = db;
        }
        public async Task<House> UpdateAsync(House entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Houses.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
