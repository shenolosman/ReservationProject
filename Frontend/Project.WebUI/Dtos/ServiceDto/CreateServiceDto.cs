using System.ComponentModel.DataAnnotations;

namespace Project.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Service Icon is needed")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Title is needed")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is needed")]
        public string Description { get; set; }
    }
}
