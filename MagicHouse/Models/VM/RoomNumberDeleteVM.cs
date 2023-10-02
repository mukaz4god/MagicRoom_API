using MagicHouse.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicHouse.Models.VM
{
    public class RoomNumberDeleteVM
    {
        public RoomNumberDeleteVM()
        {
            RoomNumber = new RoomNumberDto();
        }
        public RoomNumberDto RoomNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> HouseList { get; set; }
    }
}
