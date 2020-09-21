using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    [Table("tblCoaches")]
    public class Coach : BasePerson
    {
        [ForeignKey("Nationality")]
        public long? CountryId { get; set; }
        public Country Nationality { get; set; }

        [ForeignKey("FootballClub")]
        public long? FootballClubId { get; set; }
        public FootballClub FootballClub { get; set; }
    }
}