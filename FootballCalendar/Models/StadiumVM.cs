using FootballСalendar.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Models
{
    public class StadiumVM
    {
        public long Id { get; set; }
        public string Name { get; set; }        
        public int Capacity { get; set; }
        public string Image { get; set; }        
        public CityVM CityVM { get; set; }
    }

    public class StadiumAddVM
    {
        [Required(ErrorMessage = "Обовязкове поле"), StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public IFormFile Image { get; set; }
        public int CityId { get; set; }

        public SelectList Cities;
    }

    public class StadiumEditVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Обовязкове поле"), StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        public IFormFile Image { get; set; }
        public int CityId { get; set; }

        public SelectList City;

    }
}
