using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; } = new HashSet<Team>();

        //Navigation collection Must be always initialised 
        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; } = new HashSet<Team>();

    }
}
