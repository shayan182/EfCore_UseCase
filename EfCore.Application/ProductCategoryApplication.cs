using System;
using System.Collections.Generic;
using EfCore.Application.Contract.ProductCategory;
using EfCore.Domain.ProductCategoryAgg;

namespace EfCore.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this._productCategoryRepository = productCategoryRepository;
        }

        public void Create(CreateProductCategory command)
        {
            if (_productCategoryRepository.Exists(command.Name))
                return;
            var productCategory = new ProductCategory(command.Name);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
        }

        public void Edit(EditProductCategory command)
        {
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory==null)
                return;
            
            productCategory.Edit(command.Name);
            _productCategoryRepository.SaveChanges();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            return _productCategoryRepository.Search(name);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }
    }

}
