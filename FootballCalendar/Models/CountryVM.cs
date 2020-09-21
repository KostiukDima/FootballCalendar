using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Models
{
    public class CountryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
    }

    public class CountryAddVM
    {        
        [Required(ErrorMessage = "Обовязкове поле"), StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public IFormFile Flag { get; set; }

    }

    public class CountryEditVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Обовязкове поле"), StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public IFormFile Flag { get; set; }

    }
}
