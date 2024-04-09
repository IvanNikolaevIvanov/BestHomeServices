using BestHomeServices.Core.Contracts;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository repository;

        public ClientService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddClientAsync(string userId, string name, string address, string city, string phoneNumber)
        {
            var currentCity = await repository.AllReadOnly<City>()
                .FirstAsync(c => c.Name == city);

            await repository.AddAsync(new Client()
            {
                UserId = userId,
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                //City = currentCity,
                CityId = currentCity.Id
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ClientExistsAsync(string id)
        {
            return await repository.AllReadOnly<Client>()
                .AnyAsync(c => c.UserId == id);
        }
    }
}
