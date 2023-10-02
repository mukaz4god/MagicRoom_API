using MagicHouse.Models.Dto;

namespace MagicHouse.Services.IServices
{
	public interface IRoomNumberService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetAsync<T>(int id);
		Task<T> CreateAsync<T>(RoomNumberDto entity);
		Task<T> UpdateAsync<T>(RoomNumberDto entity);
		Task<T> DeleteAsync<T>(int id);
	}
}
