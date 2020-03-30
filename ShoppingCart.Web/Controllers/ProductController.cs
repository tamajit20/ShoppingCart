using ShoppingCart.Logic;
using ShoppingCart.ViewModel;
using System;
using System.Web.Http;

namespace ShoppingCart.Web.Controllers
{
    public class ProductController : BaseController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IHttpActionResult FetchProducts()
        {
            ProductViewModels result = new ProductViewModels();
            try
            {
                result.PopulateList(_productService.GetProducts());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}