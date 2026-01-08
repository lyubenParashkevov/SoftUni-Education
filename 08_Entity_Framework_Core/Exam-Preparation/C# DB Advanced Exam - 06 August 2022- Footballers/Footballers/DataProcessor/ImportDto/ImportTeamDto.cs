using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z0-9 .\-]+$")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; } = null!;

        public int Trophies { get; set; }

        public List<int> Footballers { get; set; } = null!;
    }
}



