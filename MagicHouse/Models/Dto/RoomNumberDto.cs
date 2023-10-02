using System.ComponentModel.DataAnnotations;

namespace MagicHouse.Models.Dto
{
    public class RoomNumberDto
    {
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public int HouseID { get; set; }
        public string SpecialDetails { get; set; }

        //public int RoomNumber { get; set; }

        public HouseDto House { get; set; }
    }
}
