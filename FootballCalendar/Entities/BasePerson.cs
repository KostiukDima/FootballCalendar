using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    public class BasePerson : BaseEntity<long>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        
        [Required, StringLength(255)]
        public string Surame { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }       

    }
}
