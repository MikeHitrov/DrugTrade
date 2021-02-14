namespace DrugTrade.Web.Areas.Administration.Controllers
{
    using DrugTrade.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {

        public DashboardController()
        {
        }

        public IActionResult Index() 
        { 

            return this.View();
        }
    }
}
