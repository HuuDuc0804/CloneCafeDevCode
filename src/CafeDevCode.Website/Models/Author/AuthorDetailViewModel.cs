using CafeDevCode.Logic.Commands.Request;
using System.ComponentModel.DataAnnotations;

namespace CafeDevCode.Website.Models
{
    public class AuthorDetailViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        [DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public CreateAuthor ToCreateCommand()
        {
            return new CreateAuthor()
            {
                IpAddress = this.IpAddress,
                FullName = this.FullName,
                Phone = this.Phone,
                Email = this.Email,
                ShortName = this.ShortName,
            };
        }
        public UpdateAuthor ToUpdateCommand()
        {
            return new UpdateAuthor()
            {
                Id = this.Id,
                IpAddress = this.IpAddress,
                FullName = this.FullName,
                Phone = this.Phone,
                Email = this.Email,
                ShortName = this.ShortName,
            };
        }
    }
}
