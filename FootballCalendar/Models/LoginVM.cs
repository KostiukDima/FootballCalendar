﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Models
{
    public class LoginVM
    {
        [Display(Name = "Електронна адреса")]
        [Required(ErrorMessage = "Вкажіть пошту")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Вкажіть пароль")]
        public string Password { get; set; }
    }
}
