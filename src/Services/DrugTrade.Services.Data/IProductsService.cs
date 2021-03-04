using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrugTrade.Services.Data
{
    public interface IProductsService
    {
        Task AddAsync(string name, string description, string manifacturer, decimal price, int quantity, string image, string pharmacyId, Pharmacy pharmacy);

        Task UpdateAsync(string id, string name, string description, string manifacturer, decimal price, int quantity, string image);

        void Delete(string id);

        List<Product> GetAllProducts();

        List<Product> GetProductsByPharmacy(string id);

        Product GetProductById(string id);
    }
}
