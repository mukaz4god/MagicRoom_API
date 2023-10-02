using AutoMapper;
using MagicHouse.Models;
using MagicHouse.Models.Dto;
using MagicHouse.Services.IServices;
using MagicHouse_Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MagicHouse.Controllers
{
    public class HomeController : Controller
    {
		private readonly IHouseService _villaService;
		private readonly IMapper _mapper;
		public HomeController(IHouseService villaService, IMapper mapper)
		{
			_villaService = villaService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			List<HouseDto> list = new();

			var response = await _villaService.GetAllAsync<APIResponse>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<HouseDto>>(Convert.ToString(response.Result));
			}
			 return View(list);
		}
	}
}