using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    [XmlType("Message")]
    public class ImportMessageDto
    {
        [XmlAttribute("SentAt")]
        public string SentAt { get; set; } = null!;

        [XmlElement("Content")]
        public string Content { get; set; } = null!;

        [XmlElement("Status")]
        public string Status { get; set; } = null!;

        [XmlElement("ConversationId")]
        public int ConversationId { get; set; }

        [XmlElement("SenderId")]
        public int SenderId { get; set; }
    }
}
