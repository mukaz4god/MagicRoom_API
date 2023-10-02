using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MagicHouse_HouseAPI.Models.Dto
{
    public class RoomNumberDto
    {
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public int HouseID { get; set; }
        public string SpecialDetails { get; set; }
        [ValidateNever]
        public HouseDto House { get; set; }
    }
}
