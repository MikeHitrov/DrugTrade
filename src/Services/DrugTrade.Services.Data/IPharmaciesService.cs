﻿using DrugTrade.Data.Models;
using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrugTrade.Services.Data
{
    interface IPharmaciesService
    {
        Pharmacy GetPharmacyById(string id);

        IEnumerable<Pharmacy> GetAllPharmacies();

        void Delete(string id);

        Task AddAsync(string name, string address, string contactNumber, byte[] profileImage, string ownerId, ApplicationUser owner);
    }
}