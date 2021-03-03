using DrugTrade.Data.Models;
using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrugTrade.Services.Data
{
    public interface IUsersService
    {
        IEnumerable<Pharmacy> GetAllUserPharmacies(string ownerId);

        ApplicationUser GerUserById(string id);

        ApplicationUser GerUserByName(string name);

        Task DeletePharmacy(string username, string pharmacyId);
    }
}
