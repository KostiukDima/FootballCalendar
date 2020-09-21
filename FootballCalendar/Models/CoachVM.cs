using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Models
{
    public class CoachVM
    {        
        public string Name { get; set; }
        public string Surame { get; set; }
        public string FullName { get { return Name + " " + Surame; } }
        public DateTime DateOfBirth { get; set; }
        public CountryVM Nationality { get; set; }
        public FootballClubVM FootballClub { get; set; }

       
    }
}
