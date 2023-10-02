using MagicHouse.Models;
using MagicHouse.Models.Dto;
using MagicHouse.Services.IServices;
using MagicHouse_Utility;
using System.Data;

namespace MagicHouse.Services
{
    public class HouseService : BaseService, IHouseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string HouseUrl;
        public HouseService(IHttpClientFactory httpClient, IConfiguration config) : base(httpClient)
        {
            _httpClientFactory = httpClient;
            HouseUrl = config.GetValue<string>("ServiceUrls:HouseAPI");
        }

        public Task<T> CreateAsync<T>(HouseDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = HouseUrl + "/api/HouseAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = HouseUrl + $"/api/HouseAPI/{id}"
            });
        }

        public Task<T> GetAllAsync<T>()
         {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = HouseUrl + "/api/HouseAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = HouseUrl + $"/api/HouseAPI/{id}"
            });
        }

        public Task<T> UpdateAsync<T>(HouseDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = HouseUrl + $"/api/HouseAPI/{dto.Id}"
            });
        }

    }
}
