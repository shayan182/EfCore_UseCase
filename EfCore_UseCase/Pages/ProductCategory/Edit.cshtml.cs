using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCore.Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EfCore_UseCase.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        public EditProductCategory Command;
        private readonly IProductCategoryApplication productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(int id)
        {
            Command = productCategoryApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost(EditProductCategory command)
        {
            productCategoryApplication.Edit(command);
            return RedirectToPage("./index");
        }
    }
}
