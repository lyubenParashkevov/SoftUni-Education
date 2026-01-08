using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ImportDtos
{
    public class BookingDto
    {
        [Required]
        [JsonProperty("BookingDate")]
        public string BookingDate { get; set; } = null!;

        [Required]
        [StringLength(60, MinimumLength = 4)]
        [JsonProperty("CustomerName")]
        public string CustomerName { get; set; } = null!;

        [Required]
        [StringLength(40, MinimumLength = 2)]
        [JsonProperty("TourPackageName")]
        public string TourPackageName { get; set; } = null!;
    }
}
