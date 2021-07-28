using EfCore.Application.Contract.ProductCategory;
using System.Collections.Generic;

namespace EfCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        ProductCategory Get(int id);
        bool Exists(string name);
        EditProductCategory GetDetails (int id);
        void Create(ProductCategory productCategory);
        void SaveChanges();
        List<ProductCategoryViewModel> Search(string name);
        List<ProductCategoryViewModel> GetAll();
    }
}
