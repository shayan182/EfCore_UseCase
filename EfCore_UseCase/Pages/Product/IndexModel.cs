using System.Collections.Generic;
using EfCore.Application.Contract.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCore_UseCase.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> products;
        private readonly IProductApplication productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            products = productApplication.Search(searchModel);
        }
    }
}
