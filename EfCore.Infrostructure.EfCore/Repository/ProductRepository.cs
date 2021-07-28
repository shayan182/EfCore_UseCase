using System.Collections.Generic;
using System.Linq;
using EfCore.Application.Contract.Product;

using EfCore.Domain.ProductAgg;
using EfCore.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Infrostructure.EfCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfContext efContext;

        public ProductRepository(EfContext efContext)
        {
            this.efContext = efContext;
        }

        public Product Get(int id)
        {
            return efContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public EditProduct GetDetails(int id)
        {
            return efContext.Products.Select(x => new EditProduct()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Name = x.Name,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public void Create(Product product)
        {
            efContext.Products.Add(product);
            efContext.SaveChanges();
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }

        public bool Exists(string name, int categoryId)
        {
            return efContext.Products.Any(x => x.Name == name && x.CategoryId == categoryId);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = efContext.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    IsRemoved = x.IsRemoved,
                    CreationDate = x.CreationDate.ToString(),
                    Category = x.Category.Name
                });
            if (searchModel.IsRemoved == true)
              query = query.Where(x => x.IsRemoved == true);

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
