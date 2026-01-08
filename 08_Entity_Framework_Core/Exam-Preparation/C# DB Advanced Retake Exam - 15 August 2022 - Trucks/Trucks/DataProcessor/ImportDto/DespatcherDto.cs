using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class DespatcherDto
    {
        [XmlElement("Name")]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [XmlElement("Position")]
        public string? Position { get; set; } = null!;

        [XmlArray("Trucks")]
        
        public TruckDto[] Trucks { get; set; } = null!;
    }
}
