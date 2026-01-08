using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    [XmlType("User")]
    public class UserDto
    {
        [XmlElement("Username")]
        public string Username { get; set; } = null!;


        [XmlArray("Posts")]
        public PostDto[] Posts { get; set; } = null!;

        [XmlAttribute("Friendships")]
        public int Count { get; set; }
    }
}
