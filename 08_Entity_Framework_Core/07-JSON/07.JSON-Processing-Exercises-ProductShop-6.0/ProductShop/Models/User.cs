namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        

        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string LastName { get; set; } = null!;

        public int? Age { get; set; }

        [InverseProperty(nameof(Product.Seller))]   //better way to write inverse property
        public virtual ICollection<Product> ProductsSold { get; set; } = new HashSet<Product>();

        [InverseProperty(nameof(Product.Buyer))]                      //[InverseProperty("Buyer")]
        public virtual ICollection<Product> ProductsBought { get; set; } = new HashSet<Product>();
    }
}