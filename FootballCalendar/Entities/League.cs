using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    [Table("tblLeagues")]
    public class League : BaseEntity<long>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public long? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<FootballGame> FootballGames { get; set; }
        public virtual ICollection<FootballClub> FootballClubs { get; set; }

    }
}
