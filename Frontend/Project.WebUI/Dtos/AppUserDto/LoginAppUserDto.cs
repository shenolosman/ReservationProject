using System.ComponentModel.DataAnnotations;

namespace Project.WebUI.Dtos.AppUserDto
{
    public class LoginAppUserDto
    {
        [Required(ErrorMessage = "Check your spelling!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Check your spelling!")]

        public string Password { get; set; }
    }
}
