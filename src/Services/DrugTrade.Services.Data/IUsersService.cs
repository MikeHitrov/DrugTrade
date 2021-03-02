using DrugTrade.Data.Models;
using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugTrade.Services.Data
{
    public interface IUsersService
    {
        IEnumerable<Pharmacy> GetAllUserPharmacies(string ownerId);

        ApplicationUser GerUserById(string id);

        ApplicationUser GerUserByName(string name);
    }
}
