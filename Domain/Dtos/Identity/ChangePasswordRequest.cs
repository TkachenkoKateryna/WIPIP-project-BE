﻿namespace Domain.Dtos.Identity
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
