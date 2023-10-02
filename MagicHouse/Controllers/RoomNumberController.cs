using AutoMapper;
using MagicHouse.Models;
using MagicHouse.Models.Dto;
using MagicHouse.Models.VM;
using MagicHouse.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MagicHouse.Controllers
{
	public class RoomNumberController : Controller
	{
		private readonly IRoomNumberService _roomNumberService;
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

		public RoomNumberController(IRoomNumberService roomNumberService, IMapper mapper, IHouseService _houseService)
		{
			_roomNumberService = roomNumberService;
			_mapper = mapper;
			this._houseService = _houseService;
		}

		public async Task<IActionResult> CreateRoomNumber()
		{
			RoomNumberCreateVM vm = new();
			var response = await _houseService.GetAllAsync<APIResponse>();
			if(response != null && response.IsSuccess)
			 {
				vm.HouseList = JsonConvert.DeserializeObject<List<HouseDto>>(Convert.ToString(response.Result)).Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				});
				
			}
            return View(vm);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateRoomNumber(RoomNumberCreateVM model)
		{
			if (ModelState.IsValid)
			{
				var response = await _roomNumberService.CreateAsync<APIResponse>(model.RoomNumber);
				if (response != null && response.IsSuccess)// && response.ErrorsMessages.Count==0)
				{
					return RedirectToAction(nameof(IndexRoomNumber));
				}
				else
				{
					if (response.ErrorsMessages.Count > 0 || response.ErrorsMessages == null)
					{
						ModelState.AddModelError("ErrorsMessages", response.ErrorsMessages.FirstOrDefault());
					}
				}
            }
			var resp = await _houseService.GetAllAsync<APIResponse>();
			if (resp != null && resp.IsSuccess)
			{
				model.HouseList = JsonConvert.DeserializeObject<List<HouseDto>>(Convert.ToString(resp.Result)).Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				});

			}
			return View(model);
		  }
		public async Task<IActionResult> IndexRoomNumber()
		{
			List<RoomNumberDto> list = new();

			var response = await _roomNumberService.GetAllAsync<APIResponse>();
			if (response != null)
			{
				list = JsonConvert.DeserializeObject<List<RoomNumberDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}


		public async Task<IActionResult> UpdateRoomNumber(int RoomNo)
		{
			RoomNumberUpdateVM vm = new();
			var response = await _roomNumberService.GetAsync<APIResponse>(RoomNo);
			if (response != null && response.IsSuccess)
			{
				RoomNumberDto model = JsonConvert.DeserializeObject<RoomNumberDto>(Convert.ToString(response.Result));
				vm.RoomNumber = _mapper.Map<RoomNumberDto>(model);
			}
			response = await _houseService.GetAllAsync<APIResponse>();
			if(response != null && response.IsSuccess)
			{
				vm.HouseList = JsonConvert.DeserializeObject<List<HouseDto>>(Convert.ToString(response.Result)).Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				});
				return View(vm);
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateRoomNumber(RoomNumberUpdateVM model)
		{
			if (ModelState.IsValid)
			{
				var response = await _roomNumberService.UpdateAsync<APIResponse>(model.RoomNumber);
				if (response != null && response.IsSuccess)// && response.ErrorsMessages.Count==0)
				{
					return RedirectToAction(nameof(IndexRoomNumber));
				}
				else
				{
					if (response.ErrorsMessages.Count > 0 || response.ErrorsMessages == null)
					{
						ModelState.AddModelError("ErrorsMessages", response.ErrorsMessages.FirstOrDefault());
					}
				}
			}
			var resp = await _houseService.GetAllAsync<APIResponse>();
			if (resp != null && resp.IsSuccess)
			{
				model.HouseList = JsonConvert.DeserializeObject<List<HouseDto>>(Convert.ToString(resp.Result)).Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				});

			}
			return View(model);
		}

		public async Task<IActionResult> DeleteRoomNumber(int RoomNo)
		{
			RoomNumberDeleteVM vm = new();
			var response = await _roomNumberService.GetAsync<APIResponse>(RoomNo);
			if (response != null && response.IsSuccess)
			{
				RoomNumberDto model = JsonConvert.DeserializeObject<RoomNumberDto>(Convert.ToString(response.Result));
				vm.RoomNumber = model;
			}
			response = await _roomNumberService.GetAllAsync<APIResponse>();
			if (response != null && response.IsSuccess)
			{
				vm.HouseList = JsonConvert.DeserializeObject<List<HouseDto>>(Convert.ToString(response.Result)).Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				});
				return View(vm);
			}
			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteRoomNumber(RoomNumberDeleteVM model)
		{

			var response = await _roomNumberService.DeleteAsync<APIResponse>(model.RoomNumber.RoomNo);
			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "Room Number deleted successfully";
				return RedirectToAction(nameof(IndexRoomNumber));
			}
			TempData["error"] = "Error encountered.";
			return View(model);
		}
	}
}
