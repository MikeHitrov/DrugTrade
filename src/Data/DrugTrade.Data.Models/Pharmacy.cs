namespace DrugTradeAPI.Models
{
    using DrugTrade.Data.Common.Models;
    using DrugTrade.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Pharmacy : BaseDeletableModel<string>
    {
        public Pharmacy()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        
        public string ContactNumber { get; set; }

        public byte[] ProfileImage { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        public ApplicationUser Owner { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
