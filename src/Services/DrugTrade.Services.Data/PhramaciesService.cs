using DrugTrade.Data.Common.Repositories;
using DrugTrade.Data.Models;
using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugTrade.Services.Data
{
    public class PhramaciesService : IPharmaciesService
    {
        private readonly IDeletableEntityRepository<Pharmacy> pharmacyRepository;
        private readonly IDeletableEntityRepository<Product> productRepository;

        public PhramaciesService(IDeletableEntityRepository<Pharmacy> pharmacyRepository, IDeletableEntityRepository<Product> productRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
            this.productRepository = productRepository;
        }

        public async Task AddAsync(string name, string address, string contactNumber, string profileImage, string ownerId, ApplicationUser owner)
        {
            Pharmacy pharmacy = new Pharmacy
            {
                Name = name,
                Address = address,
                ContactNumber = contactNumber,
                ProfileImage = profileImage,
                OwnerId = ownerId,
                Owner = owner,
            };

            await this.pharmacyRepository.AddAsync(pharmacy);
            await this.pharmacyRepository.SaveChangesAsync();
        }

        public async Task AddProductAsync(Product product, string pharmacyId)
        {
            Pharmacy pharmacy = GetPharmacyById(pharmacyId);

            pharmacy.Products.ToList().Add(product);

            this.pharmacyRepository.Update(pharmacy);
            this.pharmacyRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(string name, string address, string contactNumber, string profileImage, string id)
        {
            Pharmacy pharmacy = this.GetPharmacyById(id);

            pharmacy.Name = name;
            pharmacy.Address = address;
            pharmacy.ContactNumber = contactNumber;
            pharmacy.ProfileImage = profileImage;

            this.pharmacyRepository.Update(pharmacy);
            await this.pharmacyRepository.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Pharmacy pharmacy = GetPharmacyById(id);

            var products = pharmacy.Products;

            foreach (var product in products)
            {
                this.productRepository.Delete(product);
            }

            this.pharmacyRepository.Delete(pharmacy);
            await this.pharmacyRepository.SaveChangesAsync();
        }

        public IEnumerable<Pharmacy> GetAllPharmacies()
        {
            return this.pharmacyRepository.All().ToList();
        }

        public Pharmacy GetPharmacyById(string id)
        {
            return this.pharmacyRepository.All().Where(p => p.Id == id).FirstOrDefault();
        }

        public Pharmacy GetPharmacyByName(string name)
        {
            return this.pharmacyRepository.All().Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
