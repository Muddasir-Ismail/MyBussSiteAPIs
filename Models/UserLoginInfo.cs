using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MyBussSiteAPIs.Models
{
    public class UserLoginInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
