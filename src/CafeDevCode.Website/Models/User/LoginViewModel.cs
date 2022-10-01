using CafeDevCode.Logic.Commands.Request;
using CafeDevCode.Logic.MappingProfile;
using System.ComponentModel.DataAnnotations;

namespace CafeDevCode.Website.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không thể bỏ trống") ]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không thể bỏ trống") ]
        public string? Password { get; set; }
        public bool RememberPassword { get; set; }
        public string? ReturnUrl { get; set; }
        public string? ErrorMessage { get; set; }

        public Login ToCommand()
        {
            return new Login()
            {
                UserName = UserName,
                Password = Password,
                RememberPassword = RememberPassword,
            };
        }
    }
}
