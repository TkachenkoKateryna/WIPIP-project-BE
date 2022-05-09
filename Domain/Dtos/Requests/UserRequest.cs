﻿using Microsoft.AspNetCore.Http;

namespace Domain.Dtos.Requests
{
    public class UserRequest
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Role { get; set; }
    }
}
