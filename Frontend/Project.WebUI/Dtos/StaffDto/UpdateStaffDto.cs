using System.ComponentModel.DataAnnotations;

namespace Project.WebUI.Dtos.StaffDto
{
    public class UpdateStaffDto
    {
        public int StaffId { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Cant be empty")]
        public string SocialMedia1 { get; set; }
        public string SocialMedia2 { get; set; }
        public string SocialMedia3 { get; set; }
    }
}
