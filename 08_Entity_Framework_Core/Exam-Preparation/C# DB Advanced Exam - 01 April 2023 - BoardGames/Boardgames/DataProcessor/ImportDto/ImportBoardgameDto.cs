using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [Required]
        [StringLength(20, MinimumLength = 10)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 10.00)]
        [XmlElement("Rating")]
        public double Rating { get; set; }

        [Required]
        [Range(2018, 2023)]
        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        public string CategoryType { get; set; } = null!;


        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}
