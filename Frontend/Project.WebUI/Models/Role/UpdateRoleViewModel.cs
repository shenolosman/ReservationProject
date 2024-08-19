using System.ComponentModel.DataAnnotations;

namespace Project.WebUI.Models.Role
{
    public class UpdateRoleViewModel
    {
        [Required]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
