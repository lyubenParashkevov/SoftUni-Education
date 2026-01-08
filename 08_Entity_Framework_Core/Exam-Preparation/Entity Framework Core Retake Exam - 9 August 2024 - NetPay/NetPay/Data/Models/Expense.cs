using NetPay.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
    
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ExpenseName { get; set; } = null!;

        [Range(0.01, 100000)]
        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public PaymentStatus PaymentStatus { get; set; } 

        [Required]
        [ForeignKey(nameof(Household))]
        public int HouseholdId { get; set; }
        public virtual Household Household { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; } = null!;
    }
}

