using NetPay.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string SupplierName { get; set; } = null!;

        public virtual ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();

    }
}


