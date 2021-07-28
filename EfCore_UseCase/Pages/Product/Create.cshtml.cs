using System.Collections.Generic;
using EfCore.Application.Contract.Product;
using EfCore.Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCore_UseCase.Pages.Product
{
    public class CreateModel : PageModel
    {
        public SelectList productCategories;
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;
        public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            productCategories = new SelectList(productCategoryApplication.GetAll(),"Id","Name");
        }
        public RedirectToPageResult OnPost(CreateProduct command)
        {
            productApplication.Create(command);
            return RedirectToPage("./index");
        }
    }
}
