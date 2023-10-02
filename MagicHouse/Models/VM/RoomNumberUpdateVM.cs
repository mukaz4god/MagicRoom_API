using MagicHouse.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicHouse.Models.VM
{
    public class RoomNumberUpdateVM
    {
        public RoomNumberUpdateVM()
        {
            RoomNumber = new RoomNumberDto();
        }
        public RoomNumberDto RoomNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> HouseList { get; set; }
    }
}
