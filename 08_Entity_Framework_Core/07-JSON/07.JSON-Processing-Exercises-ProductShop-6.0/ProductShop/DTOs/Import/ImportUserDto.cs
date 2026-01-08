using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Import
{
    public class ImportUserDto
    {
        
        [JsonProperty(nameof(FirstName))]
        public string? FirstName { get; set; }
        [Required]
        [JsonProperty(nameof(LastName))]
        public string LastName { get; set; } = null!;
        [JsonProperty(nameof(Age))]
        public string? Age { get; set; }
    }
}
