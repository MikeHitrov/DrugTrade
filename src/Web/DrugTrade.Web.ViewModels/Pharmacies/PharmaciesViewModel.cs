using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugTrade.Web.ViewModels.Pharmacies
{
    public class PharmaciesViewModel
    {
        public PharmaciesViewModel(IEnumerable<Pharmacy> pharmacies, string userId)
        {
            this.Pharmacies = pharmacies;
            this.UserId = userId;
        }

        public IEnumerable<Pharmacy> Pharmacies { get; set; }

        public string UserId { get; set; }
    }
}
