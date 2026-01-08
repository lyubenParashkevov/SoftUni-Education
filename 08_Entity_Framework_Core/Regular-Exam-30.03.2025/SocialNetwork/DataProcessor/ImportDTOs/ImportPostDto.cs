using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    public class ImportPostDto
    {
        public string Content { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public int CreatorId { get; set; }
    }
}
