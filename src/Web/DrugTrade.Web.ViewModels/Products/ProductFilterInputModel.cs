using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DrugTrade.Web.ViewModels.Products
{
    public class ProductFilterInputModel
    {
        [Required]
        public string PharmacyName { get; set; }
    }
}
