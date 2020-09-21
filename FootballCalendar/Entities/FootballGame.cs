using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    [Table("tblFootballGames")]
    public class FootballGame : BaseEntity<long>
    {

        [ForeignKey("HomeTeam")]
        public long? HomeTeamId { get; set; }
        public HomeTeam HomeTeam { get; set; }
        
        [ForeignKey("OpponentTeam")]
        public long? OpponentTeamId { get; set; }
        public OpponentTeam OpponentTeam { get; set; }


        [ForeignKey("Stadium")]
        public long? StadiumId { get; set; }
        public Stadium Stadium { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("League")]
        public long? LeagueId { get; set; }
        public League League { get; set; }

        [ForeignKey("GameStatus")]
        public long? GameStatusId { get; set; }
        public GameStatus GameStatus { get; set; }
    }
}
