using MagicHouse.Models.Dto;

namespace MagicHouse.Services.IServices
{
    public interface IHouseService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(HouseDto id);
        Task<T> UpdateAsync<T>(HouseDto entity);
        Task<T> DeleteAsync<T>(int id);

    }
}
