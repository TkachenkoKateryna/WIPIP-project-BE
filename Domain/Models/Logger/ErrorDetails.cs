﻿using System.Text.Json;

namespace Domain.Models.Logger
{
    public class ErrorDetails
    {
        public bool Base { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
