using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.Data.Models
{
    public class Household
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ContactPerson { get; set; } = null!;

        [StringLength(80, MinimumLength = 6)]
        public string? Email {  get; set; }

        [Required]
        [StringLength (15)]
        [RegularExpression("@\"^\\+\\d{3}/\\d{3}-\\d{6}$\"")]
        public string PhoneNumber { get; set; } = null!;


        public virtual ICollection<Expense> Expenses { get; set;  } = new HashSet<Expense>();
    }
}



