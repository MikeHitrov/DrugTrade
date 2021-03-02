using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrugTrade.Services.Data
{
    interface IProductsService
    {
        Task AddAsync(string name, string description, decimal price, int quantity, byte[] image, string pharmacyId, Pharmacy pharmacy);

        Task UpdateAsync(string name, string description, decimal price, int quantity, byte[] image, string pharmacyId, Pharmacy pharmacy);

        void Delete(string id);

        List<Product> GetAllProducts(string id);

        List<Product> GetProductsByPharmacy(string id);
    }
}
