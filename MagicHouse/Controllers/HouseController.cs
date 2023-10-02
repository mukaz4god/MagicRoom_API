using AutoMapper;
using MagicHouse.Models;
using MagicHouse.Models.Dto;
using MagicHouse.Services.IServices;
using MagicHouse_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicHouse.Controllers
{
	public class HouseController : Controller
	{
		private readonly IHouseService _houseService;
		private readonly IMapper _mapper;

		public HouseController(IHouseService homeService, IMapper mapper)
		{
			_houseService = homeService;
			_mapper = mapper;
		}

		public async Task<IActionResult> CreateHouse()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateHouse(HouseDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await _houseService.CreateAsync<APIResponse>(model);
				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "House created successfully";
					return RedirectToAction(nameof(IndexHouse));
				}
			}
			TempData["error"] = "Error encountered.";
			return View(model);
		}
		public async Task<IActionResult> IndexHouse()
		{
			List<HouseDto> list = new();

			var response = await _houseService.GetAllAsync<APIResponse>();
			if (response != null)
			{
				list = JsonConvert.DeserializeObject<List<HouseDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}


		public async Task<IActionResult> UpdateHouse(int HouseId)
		{
			var response = await _houseService.GetAsync<APIResponse>(HouseId);
			if (response != null && response.IsSuccess)
			{
				HouseDto model = JsonConvert.DeserializeObject<HouseDto>(Convert.ToString(response.Result));
				return View(_mapper.Map<HouseDto>(model));
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateHouse(HouseDto model)
		{
			if (ModelState.IsValid)
			{
				TempData["success"] = "House updated successfully";
				var response = await _houseService.UpdateAsync<APIResponse>(model);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(IndexHouse));
				}
			}
			TempData["error"] = "Error encountered.";
			return View(model);
		}
	
		public async Task<IActionResult> DeleteHouse(int HouseId)
		{
			var response = await _houseService.GetAsync<APIResponse>(HouseId);
			if (response != null && response.IsSuccess)
			{
				HouseDto model = JsonConvert.DeserializeObject<HouseDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteHouse(HouseDto model)
		{

			var response = await _houseService.DeleteAsync<APIResponse>(model.Id);
			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "House deleted successfully";
				return RedirectToAction(nameof(IndexHouse));
			}
			TempData["error"] = "Error encountered.";
			return View(model);
		}
	}
}