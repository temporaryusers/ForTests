using System.ComponentModel.DataAnnotations;

namespace Transcript.WebUI.Models
{
    public class LoginModel
    {
        [Required]
        public string login { get; set; } /* логин пользователя */

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; } /* пароль пользователя */
    }
}