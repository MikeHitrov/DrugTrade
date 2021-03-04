using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugTrade.Web.ViewModels.Products
{
    public class ProductViewModel
    {
        public ProductViewModel(IEnumerable<Product> products, string userId, string pharmacyOwnerId)
        {
            this.Products = products;
            this.UserId = userId;
            this.PharmacyOwnerId = pharmacyOwnerId;
        }

        public IEnumerable<Product> Products { get; set; }

        public string UserId { get; set; }

        public string PharmacyOwnerId { get; set; }
    }
}
