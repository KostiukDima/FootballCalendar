using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    [Table("tblGameStatuses")]

    public class GameStatus : BaseEntity<long>
    {
        [Required, StringLength(255)]
        public string Status { get; set; }

        public virtual ICollection<FootballGame> FootballGames { get; set; }

    }
}
