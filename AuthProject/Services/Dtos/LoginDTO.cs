using System.ComponentModel.DataAnnotations;

namespace AuthProject.Services.Dtos
{
    public class LoginDTO
    {
        //we can use resources for message
        [Required(ErrorMessage = "Enter userName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
    }
}
