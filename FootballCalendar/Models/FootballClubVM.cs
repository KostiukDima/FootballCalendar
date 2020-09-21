using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Models
{
    public class FootballClubVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public CityVM City { get; set; }
        public StadiumVM HomeStadium { get; set; }
        public CoachVM Coach { get; set; }
        public LeageVM League { get; set; }
    }

    public class FootballClubAddVM
    {
        
        [Required(ErrorMessage = "Обовязкове поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обовязкове поле")]
        public IFormFile Logo { get; set; }
        [Required(ErrorMessage = "Обовязкове поле")]
        
        public int CityId { get; set; }
        public SelectList Cities;

        public int StadiumId { get; set; }
        public SelectList Stadiums;
        public int CoachId { get; set; }
        public SelectList Coaches;
        public int LeagueId { get; set; }
        public SelectList Leagues { get; set; }
    }
}
