using EfCore.Application.Contract.Product;
using EfCore.Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCore_UseCase.Pages.Product
{
    public class EditModel : PageModel
    {
        public EditProduct Command;
        public SelectList ProductCategories;
        private readonly IProductCategoryApplication productCategoryApplication;
        private readonly IProductApplication productApplication;

        public EditModel(IProductApplication productApplication, IProductCategoryApplication categoryApplication)
        {
            this.productApplication = productApplication;
            productCategoryApplication = categoryApplication;
        }

        public void OnGet(int id)
        {
            ProductCategories = new SelectList(productCategoryApplication.GetAll(), "Id", "Name");
            Command = productApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost(EditProduct command)
        {
            productApplication.Edit(command);
            return RedirectToPage("./index");
        }
    }
}
