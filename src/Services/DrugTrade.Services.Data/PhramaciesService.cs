﻿using DrugTrade.Data.Common.Repositories;
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

        public PhramaciesService(IDeletableEntityRepository<Pharmacy> pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public async Task AddAsync(string name, string address, string contactNumber, byte[] profileImage, string ownerId, ApplicationUser owner)
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

            this.pharmacyRepository.AddAsync(pharmacy);
            this.pharmacyRepository.SaveChangesAsync();
        }

        public async Task AddProductAsync(Product product, string pharmacyId)
        {
            Pharmacy pharmacy = GetPharmacyById(pharmacyId);

            pharmacy.Products.ToList().Add(product);

            this.pharmacyRepository.Update(pharmacy);
            this.pharmacyRepository.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            Pharmacy pharmacy = GetPharmacyById(id);

            this.pharmacyRepository.Delete(pharmacy);
            this.pharmacyRepository.SaveChangesAsync();
        }

        public IEnumerable<Pharmacy> GetAllPharmacies()
        {
            return this.pharmacyRepository.All().ToList();
        }

        public Pharmacy GetPharmacyById(string id)
        {
            return this.pharmacyRepository.All().Where(p => p.Id == id).FirstOrDefault();
        }
    }
}