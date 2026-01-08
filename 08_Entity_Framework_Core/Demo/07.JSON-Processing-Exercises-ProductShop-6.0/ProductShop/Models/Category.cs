namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        //public Category()
        //{
        //    CategoriesProducts = new HashSet<CategoryProduct>();  initialized below
        //}

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<CategoryProduct> CategoriesProducts { get; set; }
            = new HashSet<CategoryProduct>();
    }
}
