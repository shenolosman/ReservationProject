using System.ComponentModel.DataAnnotations;

namespace Project.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        [Required(ErrorMessage = "Cant be empty")]
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string Description { get; set; }
    }
}
