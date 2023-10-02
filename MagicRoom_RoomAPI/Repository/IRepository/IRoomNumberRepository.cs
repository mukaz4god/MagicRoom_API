using MagicHouse_HouseAPI.Models;

namespace MagicHouse_HouseAPI.Repository.IRepository
{
    public interface IRoomNumberRepository: IRepository<RoomNumber>
    {
        Task<RoomNumber> UpdateAsync(RoomNumber entity);
    }
}
