using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicHouse_HouseAPI.Models
{
    public class RoomNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int RoomNo { get; set; }
        [ForeignKey("HouseID")]
        public int HouseID { get; set; }
        public House House { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
    }
}
