using MagicHouse_HouseAPI.Models;
using System.Linq.Expressions;

namespace MagicHouse_HouseAPI.Repository.IRepository
{
    public interface IHouseRepository : IRepository<House>
    {
        Task<House> UpdateAsync(House entity);

    }
}
