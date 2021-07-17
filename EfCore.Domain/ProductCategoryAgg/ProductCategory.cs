using System;
using System.Collections.Generic;
using EfCore.Domain.productAgg;

namespace EfCore.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public ProductCategory(string name)
        {
            Name = name;
            CreationDate = DateTime.Now;
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public DateTime CreationDate { get; set; }

        public void Edit(string name)
        {
            Name = name;
        }

    }
}