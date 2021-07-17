using System;
using EfCore.Domain.ProductCategoryAgg;

namespace EfCore.Domain.productAgg
{
    public class Product
    {
        public Product(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }

        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public void Edit(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CreationDate = DateTime.Now;
            CategoryId = categoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }

    }

   
}
