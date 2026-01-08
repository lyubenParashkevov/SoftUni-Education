namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<CategoryProduct> CategoriesProducts { get; set; }
                = new HashSet<CategoryProduct>();
    }
}
