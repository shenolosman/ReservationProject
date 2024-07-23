using System.ComponentModel.DataAnnotations;

namespace Project.WebUI.Dtos.ServiceDto
{
    public class ResultServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
