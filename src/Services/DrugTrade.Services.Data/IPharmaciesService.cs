using DrugTrade.Data.Models;
using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrugTrade.Services.Data
{
    public interface IPharmaciesService
    {
        Pharmacy GetPharmacyById(string id);

        IEnumerable<Pharmacy> GetAllPharmacies();

        Task Delete(string id);

        Task AddAsync(string name, string address, string contactNumber, string profileImage, string ownerId, ApplicationUser owner);

        Task AddProductAsync(Product product, string pharmacyId);

        Task UpdateAsync(string name, string address, string contactNumber, string profileImage, string id);
    }
}
