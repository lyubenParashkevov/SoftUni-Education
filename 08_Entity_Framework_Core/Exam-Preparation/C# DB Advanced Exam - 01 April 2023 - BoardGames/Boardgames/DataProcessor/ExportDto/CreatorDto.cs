using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class CreatorDto
    {
        [XmlElement("CreatorName")]
        public string Name { get; set; } = null!;

        [XmlAttribute("BoardgamesCount")]
        public int Count { get; set; }

        [XmlArray("Boardgames")]
        public BoardgameDto[] Games { get; set; } = null!;

    }
}
