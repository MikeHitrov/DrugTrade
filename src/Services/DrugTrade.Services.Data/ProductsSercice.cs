using DrugTrade.Data.Common.Repositories;
using DrugTrade.Data.Models;
using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugTrade.Services.Data
{
    public class ProductsSercice : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public ProductsSercice(IDeletableEntityRepository<Product> productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task AddAsync(string name, string description, decimal price, int quantity, string image, string pharmacyId, Pharmacy pharmacy)
        {
            var product = new Product
            {
               Name = name,
               Description =description,
               Price = price,
               Quantity = quantity,
               Image = image,
               PharmacyId = pharmacyId,
               Pharmacy = pharmacy,
            };

            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            Product product = GetProductById(id);

            this.productsRepository.Delete(product);
            this.productsRepository.SaveChangesAsync();
        }

        public List<Product> GetAllProducts()
        {
            return this.productsRepository.All().ToList();
        }

        public Product GetProductById(string id)
        {
            return this.productsRepository.All().Where(p => p.Id == id).FirstOrDefault();
        }

        public List<Product> GetProductsByPharmacy(string id)
        {
            return this.productsRepository.All().Where(p => p.PharmacyId == id).ToList();
        }

        public async Task UpdateAsync(string id, string name, string description, decimal price, int quantity, string image)
        {
            var product = GetProductById(id);

            product.Name = name;
            product.Description = description;
            product.Price = price;
            product.Quantity = quantity;
            product.Image = image;

            this.productsRepository.Update(product);
            this.productsRepository.SaveChangesAsync();
        }
    }
}
