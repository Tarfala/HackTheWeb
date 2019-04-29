﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackingTheWeb.Models
{
    public class Login
    {
        [Key]
        public string Username { get; set; }
        [Display(Name = "Password")]
        public string SecretPassWord { get; set; }
    }
}
