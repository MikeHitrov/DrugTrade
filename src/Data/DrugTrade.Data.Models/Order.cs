using DrugTrade.Data.Common.Models;
using DrugTrade.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrugTradeAPI.Models
{
    public class Order : IDeletableEntity
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string PharmacyId { get; set; }

        [Required]
        public Pharmacy Pharmacy { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public  DateTime DateCreated { get; set; }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
