using System.Collections.Generic;
using System.Linq;
using EfCore.Application.Contract.ProductCategory;
using EfCore.Domain.ProductCategoryAgg;
using EfCore.Infrastructure.EfCore;

namespace EfCore.Infrostructure.EfCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EfContext _efContext;

        public ProductCategoryRepository(EfContext efContext)
        {
            this._efContext = efContext;
        }


        public EditProductCategory GetDetails(int id)
        {
            return _efContext.ProductCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }

        public void Create(ProductCategory productCategory)
        {
            _efContext.ProductCategories.Add(productCategory);
            SaveChanges();
        }

        public bool Exists(string name)
        {
            return _efContext.ProductCategories.Any(x => x.Name == name);
        }

        public ProductCategory Get(int id)
        {
            return _efContext.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _efContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditProductCategory Details(int id)
        {
            return _efContext.ProductCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _efContext.SaveChanges();
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            var query = _efContext.ProductCategories
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreationDate = x.CreationDate.ToString()
                });

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
