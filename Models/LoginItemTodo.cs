﻿using System.ComponentModel.DataAnnotations;

namespace OfficeAPI.Models
{
    public class LoginItemTodo
    {
        [Key]
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsLoggedIn { get; set; }
    }
}
