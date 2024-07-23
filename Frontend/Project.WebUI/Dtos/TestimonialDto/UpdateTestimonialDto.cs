using System.ComponentModel.DataAnnotations;

namespace Project.WebUI.Dtos.TestimonialDto
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
