
using Lahor.Core.Dto;

namespace Lahor.Shared.Models
{
    public class LoginInformation
    {
        public ApplicationUserDto User { get; set; }
        public string Token { get; set; }
    }
}
