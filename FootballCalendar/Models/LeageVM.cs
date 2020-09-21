using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Models
{
    public class LeageVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual CountryVM Country { get; set; }
    }

    public class LeageAddVM
    {        
        [Required(ErrorMessage = "Обовязкове поле"), StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public int CountryId { get; set; }

        public SelectList Countries;

    }   
}
