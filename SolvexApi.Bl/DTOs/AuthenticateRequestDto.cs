using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericApi.Bl.DTOs
{
    public class AuthenticateRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
