﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.AuthenticateDto
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
