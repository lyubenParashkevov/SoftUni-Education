using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ImportDto
{
    public class ProductDto
    {
        [Required]
        [StringLength(30, MinimumLength = 9)]
        [Unicode]
        public string Name { get; set; } = null!;

        [Range(5.00, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 4)]
        public CategoryType CategoryType { get; set; }

        public int[] Clients { get; set; } = null!;
    }
}

