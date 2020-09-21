using FootballСalendar.Entities;
using FootballСalendar.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Models
{

    public class CityVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CountryVM Country { get; set; }
}

    public class CityAddVM
    {
        [Required(ErrorMessage = "Обовязкове поле"), StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public int CountryId { get; set; }

        public SelectList Countries;

    }

    public class CityEditVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Обовязкове поле"), StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public CountryVM Country { get; set; }

    }

}
