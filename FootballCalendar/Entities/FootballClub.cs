using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{   

    [Table("tblFootballClubs")]
    public class FootballClub : BaseEntity<long>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Logo { get; set; }

        [ForeignKey("City")]
        public long? CityId { get; set; }
        public City City { get; set; }

        [ForeignKey("Stadium")]
        public long? HomeStadiumId { get; set; }
        public Stadium HomeStadium { get; set; }

        [ForeignKey("Coach")]
        public long? CoachId { get; set; }
        public Coach Coach { get; set; }

        [ForeignKey("League")]
        public long? LeagueId { get; set; }
        public League League { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<HomeTeam> HomeTeams { get; set; }
        public virtual ICollection<OpponentTeam> OpponentTeams { get; set; }
    }
}
