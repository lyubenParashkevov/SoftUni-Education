using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression("^www\\.[a-zA-Z0-9-]+\\.com$")]
        public string Website { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();

    }
}
