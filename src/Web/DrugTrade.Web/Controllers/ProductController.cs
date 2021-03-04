using DrugTrade.Services.Data;
using DrugTrade.Web.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugTrade.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IPharmaciesService pharmaciesService;
        private readonly IProductsService productsService;

        public ProductController(IUsersService usersService, IProductsService productsService, IPharmaciesService pharmaciesService)
        {
            this.usersService = usersService;
            this.productsService = productsService;
            this.pharmaciesService = pharmaciesService;
        }

        public IActionResult Add()
        {
            var userId = this.usersService.GerUserByName(this.User.Identity.Name).Id;
            var pharmacies = this.usersService.GetAllUserPharmacies(userId);


            ViewBag.Pharmacies = pharmacies;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(ProductInputModel inputModel)
        {
            var pharmacy = inputModel.Pharmacy;

            await this.productsService.AddAsync(inputModel.Name, inputModel.Description, inputModel.Manifacturer, inputModel.Price, inputModel.Quantity, inputModel.Image, pharmacy, this.pharmaciesService.GetPharmacyById(pharmacy));

            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var products = this.productsService.GetAllProducts();

            var userId = this.usersService.GerUserByName(this.User.Identity.Name).Id;

            foreach (var product in products)
            {
                product.Pharmacy = this.pharmaciesService.GetPharmacyById(product.PharmacyId);
            }

            ProductViewModel viewModel = new ProductViewModel(products, userId, "");

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var product = this.productsService.GetProductById(id);

            var inputModel = new ProductInputModel
            {
                Id = id,
                Name = product.Name,
                Manifacturer = product.Мanifacturer,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Image = product.Image,
            };

            ViewBag.Data = inputModel;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(ProductInputModel inputModel)
        {
            await this.productsService.UpdateAsync(inputModel.Id, inputModel.Name, inputModel.Description, inputModel.Manifacturer, inputModel.Price, inputModel.Quantity, inputModel.Image);

            return this.Redirect("/Product/List");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var meeting = this.productsService.GetProductById(id);

            this.productsService.Delete(id);

            return this.Redirect("/Product/List");
        }

        [Authorize]
        public async Task<IActionResult> Filter(string pharmacyName)
        {
            var pharmacyId = this.pharmaciesService.GetPharmacyByName(pharmacyName).Id;
            var products = this.productsService.GetProductsByPharmacy(pharmacyId);

            var userId = this.usersService.GerUserByName(this.User.Identity.Name).Id;

            foreach (var product in products)
            {
                product.Pharmacy = this.pharmaciesService.GetPharmacyById(product.PharmacyId);
            }

            ProductViewModel viewModel = new ProductViewModel(products, userId, "");

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Filter(ProductInputModel inputModel)
        {
            await this.productsService.UpdateAsync(inputModel.Id, inputModel.Name, inputModel.Description, inputModel.Manifacturer, inputModel.Price, inputModel.Quantity, inputModel.Image);

            return this.Redirect("/Product/List");
        }
    }
}
