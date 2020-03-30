using ShoppingCart.Logic;
using ShoppingCart.ViewModel;
using System;
using System.Web.Http;

namespace ShoppingCart.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IHttpActionResult AddCategory(CategoryViewModel category)
        {
            try
            {
                category.Id = _categoryService.AddCategory(category.ConvertToDBEntity(category));
                return Ok(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IHttpActionResult FetchCategories()
        {
            CategoryViewModels result = new CategoryViewModels();
            try
            {
                result.PopulateList(_categoryService.GetCategories());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}