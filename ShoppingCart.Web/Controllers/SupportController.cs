using ShoppingCart.Logic;
using ShoppingCart.ViewModel;
using System;
using System.Web.Http;

namespace ShoppingCart.Web.Controllers
{
    public class SupportController : ApiController
    {
        private ISupportService _supportService;

        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        public IHttpActionResult AddConactUs(ContactUsViewModel input)
        {
            try
            {
                input.Id = _supportService.AddContactUs(input.ConvertToDBEntity(input));
                return Ok(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IHttpActionResult FetchContactUsTypes()
        {
            ConactUsTypeViewModels result = new ConactUsTypeViewModels();
            try
            {
                result.PopulateList(_supportService.GetContactUsTypes());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}