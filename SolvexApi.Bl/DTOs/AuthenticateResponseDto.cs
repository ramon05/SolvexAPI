﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.DTOs
{
    public class AuthenticateResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

    }
}
