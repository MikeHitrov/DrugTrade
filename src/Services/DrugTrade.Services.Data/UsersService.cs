using DrugTrade.Data.Common.Repositories;
using DrugTrade.Data.Models;
using DrugTradeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugTrade.Services.Data
{
    class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Pharmacy> phrmaciesRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository, IDeletableEntityRepository<Pharmacy> phrmaciesRepository)
        {
            this.usersRepository = usersRepository;
            this.phrmaciesRepository = phrmaciesRepository;
        }

        public ApplicationUser GerUserById(string id)
        {
            return this.usersRepository.All().Where(u => u.Id == id).FirstOrDefault();
        }

        public IEnumerable<Pharmacy> GetAllUserPharmacies(string ownerId)
        {
            return this.phrmaciesRepository.All().Where(p => p.OwnerId == ownerId);
        }
    }
}
