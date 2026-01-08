using NetPay.Data.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.DataProcessor.ImportDtos
{
    public class ExpensesDto
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [JsonProperty("ExpenseName")]
        public string ExpenseName { get; set; } = null!;

        [Range(0.01, 100000)]
        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; } = null!;

        [JsonProperty("PaymentStatus")]
        public string PaymentStatus { get; set; } = null!;

        [JsonProperty("HouseholdId")]
        public int HouseholdId { get; set; }

        [JsonProperty("ServiceId")]
        public int ServiceId { get; set; }
    }
}


 