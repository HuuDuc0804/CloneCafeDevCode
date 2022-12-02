using CafeDevCode.Logic.Commands.Request;
using System.ComponentModel.DataAnnotations;

namespace CafeDevCode.Website.Models
{
    public class UserDetailViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string DetailUserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public CreateUser ToCreateCommand()
        {
            return new CreateUser()
            {
                CreateUserName = this.DetailUserName ?? string.Empty,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                AuthorId = this.AuthorId,
                Password = this.Password,
            };
        }
        public UpdateUser ToUpdateCommand()
        {
            return new UpdateUser()
            {
                UpdateUserName = this.DetailUserName ?? string.Empty,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                AuthorId = this.AuthorId,
            };
        }
    }
}
