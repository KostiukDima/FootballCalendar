using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    [Table("tblCities")]
    public class City : BaseEntity<long>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public long? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Stadium> Stadiums { get; set; }
        public virtual ICollection<FootballClub> FootballClubs { get; set; }

    }
}
