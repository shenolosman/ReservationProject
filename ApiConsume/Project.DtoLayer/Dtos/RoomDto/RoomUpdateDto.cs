using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please enter room number!")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Please enter price information!")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter title!")]
        [StringLength(100,ErrorMessage ="You can write maximum 100 chars!")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string Wifi { get; set; }
    }
}
