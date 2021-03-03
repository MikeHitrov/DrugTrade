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
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Pharmacy> phrmaciesRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository, IDeletableEntityRepository<Pharmacy> phrmaciesRepository)
        {
            this.usersRepository = usersRepository;
            this.phrmaciesRepository = phrmaciesRepository;
        }

        public async Task DeletePharmacy(string username, string pharmacyId)
        {
            ApplicationUser user = this.GerUserByName(username);

            user.Pharmacies = user.Pharmacies.ToList().Where(p => p.Id != pharmacyId).ToList();

            this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();
        }

        public ApplicationUser GerUserById(string id)
        {
            return this.usersRepository.All().Where(u => u.Id == id).FirstOrDefault();
        }

        public ApplicationUser GerUserByName(string name)
        {
            return this.usersRepository.All().Where(u => u.UserName == name).FirstOrDefault();
        }

        public IEnumerable<Pharmacy> GetAllUserPharmacies(string ownerId)
        {
            return this.phrmaciesRepository.All().Where(p => p.OwnerId == ownerId);
        }
    }
}
