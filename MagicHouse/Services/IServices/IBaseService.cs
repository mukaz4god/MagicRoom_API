using MagicHouse.Models;

namespace MagicHouse.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest request);
    }
}
