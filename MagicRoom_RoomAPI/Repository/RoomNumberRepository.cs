using MagicHouse_HouseAPI.Data;
using MagicHouse_HouseAPI.Models;
using MagicHouse_HouseAPI.Repository.IRepository;
using MagicT_TAPI.Repository;

namespace MagicHouse_HouseAPI.Repository
{
    public class RoomNumberRepository : Repository<RoomNumber>, IRoomNumberRepository
    {
        private readonly ApplicationDBContext _db;
        public RoomNumberRepository(ApplicationDBContext db) : base(db)
        {
            _db= db;
        }

        public async Task<RoomNumber> UpdateAsync(RoomNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            //_db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
