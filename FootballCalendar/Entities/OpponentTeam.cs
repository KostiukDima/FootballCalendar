using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    [Table("tblOpponentTeams")]
    public class OpponentTeam : BaseEntity<long>
    {
        public int GoalCount { get; set; }
        [ForeignKey("FootballClub")]
        public long? FootballClubId { get; set; }
        public FootballClub FootballClub { get; set; }

        [ForeignKey("FootballGame")]
        public long? FootballGameId { get; set; }
        public FootballGame FootballGame { get; set; }
    }
}
