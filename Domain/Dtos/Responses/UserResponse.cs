using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Responses
{
    public class UserResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string ImageLink { get; set; }
        public string Role { get; set; }
    }
}
