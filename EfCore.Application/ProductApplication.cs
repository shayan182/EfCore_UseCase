using System.Collections.Generic;
using EfCore.Application.Contract.Product;
using EfCore.Domain.ProductAgg;

namespace EfCore.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository ProductRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public void Create(CreateProduct command)
        {
            if (ProductRepository.Exists(command.Name,command.CategoryId))
                return;

            var product = new Product(command.Name, command.UnitPrice, command.CategoryId);
            ProductRepository.Create(product);
        }

        public void Edit(EditProduct command)
        {
            var product = ProductRepository.Get(command.Id);
            if (product==null)
                return;

            product.Edit(command.Name,command.UnitPrice,command.CategoryId);
            ProductRepository.SaveChanges();
        }

        public void Remove(int id)
        {
            var product = ProductRepository.Get(id);
            if (product == null)
                return;

            product.Remove();
            ProductRepository.SaveChanges();
        }

        public void Restore(int id)
        {
            var product = ProductRepository.Get(id);
            if (product == null)
                return;

            product.Restore();
            ProductRepository.SaveChanges();
        }

        public EditProduct GetDetails(int id)
        {
            return ProductRepository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return ProductRepository.Search(searchModel);
        }
    }
}
