using MagicHouse.Models;
using MagicHouse.Models.Dto;
using MagicHouse.Services.IServices;
using MagicHouse_Utility;
using System.Net.Http;

namespace MagicHouse.Services
{
	public class RoomNumberService: BaseService, IRoomNumberService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private string HouseUrl;
		public RoomNumberService(IHttpClientFactory httpClient, IConfiguration config) : base(httpClient)
		{ 
			_httpClientFactory = httpClient;
			HouseUrl = config.GetValue<string>("ServiceUrls:HouseAPI");
		}

		public Task<T> CreateAsync<T>(RoomNumberDto dto)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = dto,
				Url = HouseUrl + "/api/RoomNumberAPI"
			});
		}

		public Task<T> DeleteAsync<T>(int id)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.DELETE,
				Url = HouseUrl + $"/api/RoomNumberAPI/{id}"
			}); ;
		}

		public Task<T> GetAllAsync<T>()
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = HouseUrl + "/api/RoomNumberAPI"
			});
		}

		public Task<T> GetAsync<T>(int id)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.GET,
				Url = HouseUrl + $"/api/RoomNumberAPI/{id}"
			});
		}

		public Task<T> UpdateAsync<T>(RoomNumberDto dto)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = dto,
				Url = HouseUrl + $"/api/HouseAPI/{dto.RoomNo}"
			});
		}
	}
}
