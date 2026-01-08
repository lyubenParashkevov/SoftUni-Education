using Footballers.Data.Models.Enums;
using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; } = null!;

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; } = null!;

        [Required]
        [XmlElement("PositionType")]
        public string PositionType { get; set; } = null!;


        [Required]
        [XmlElement("BestSkillType")]
         public string BestSkillType { get; set; } = null!;

      
    }
}
