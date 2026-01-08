using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.DataProcessor.ImportDto
{
    public class ClientDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(40, MinimumLength = 2)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; } = null!;

        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; } = null!;

       // [JsonProperty("ClientsTrucks")]
        public int[] Trucks { get; set; } = null!;
    }
}
