using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    [Table("tblStadiums")]
    public class Stadium : BaseEntity<long>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }  
        
        [Required]
        public int Capacity { get; set; }

        [Required, StringLength(255)]
        public string Image { get; set; }

        [ForeignKey("City")]
        public long? CityId { get; set; }
        public City City { get; set; }
        public virtual ICollection<FootballGame> FootballGames { get; set; }
        public virtual ICollection<FootballClub> FootballClubs { get; set; }
    }  
}
