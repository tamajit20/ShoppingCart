using ShoppingCart.Logic;
using ShoppingCart.ViewModel;
using System;
using System.Web.Http;

namespace ShoppingCart.Web.Controllers
{
    public class DashboardController : BaseController
    {
        private IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashbboardService)
        {
            _dashboardService = dashbboardService;
        }

        [HttpGet]
        public IHttpActionResult GetCarousellComponents()
        {
            CarousellCompomentViewModels result = new CarousellCompomentViewModels();
            try
            {
                result.PopulateList(_dashboardService.GetCarousellComponents());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IHttpActionResult GetBoxComponents()
        {
            BoxCompomentViewModels result = new BoxCompomentViewModels();
            try
            {
                result.PopulateList(_dashboardService.GetBoxComponents());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
