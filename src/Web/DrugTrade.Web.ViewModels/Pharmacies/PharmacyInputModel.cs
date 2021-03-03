using DrugTrade.Services.Mapping;
using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DrugTrade.Web.ViewModels.Pharmacies
{
    public class PharmacyInputModel: IMapTo<Pharmacy>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string ProfileImage { get; set; }

        [Required]
        public string OwnerId { get; set; }
    }
}
