using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugTrade.Services.Data;
using Microsoft.AspNetCore.Authorization;
using DrugTrade.Web.ViewModels.Pharmacies;
using System.IO;
using DrugTrade.Data.Models;

namespace DrugTrade.Web.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IPharmaciesService pharmaciesService;

        public PharmacyController(IUsersService usersService, IPharmaciesService pharmaciesService)
        {
            this.usersService = usersService;
            this.pharmaciesService = pharmaciesService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(PharmacyInputModel inputModel)
        {
            ApplicationUser user = this.usersService.GerUserByName(this.User.Identity.Name); 

            await this.pharmaciesService.AddAsync(inputModel.Name, inputModel.Address, inputModel.ContactNumber, inputModel.ProfileImage, user.Id, user);

            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var pharmacies = this.pharmaciesService.GetAllPharmacies();

            var userId = this.usersService.GerUserByName(this.User.Identity.Name).Id;

            PharmaciesViewModel viewModel = new PharmaciesViewModel(pharmacies, userId);

            return this.View(viewModel);
        }
    }
}
