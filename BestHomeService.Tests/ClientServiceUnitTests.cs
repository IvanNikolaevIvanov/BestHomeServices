using BestHomeServices.Core.Models.Client;
using BestHomeServices.Core.Services;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.UnitTests
{
    public class ClientServiceUnitTests : UnitTestsBase
    {
        private ClientService clientService;
        private Specialist testSpecialist;
        private IRepository testRepository;

        [SetUp]
        public void SetUp()
        {
            clientService = new ClientService(repository);
            testSpecialist = SecondSpecialist;
            testRepository = repository;
        }

        [Test]
        public async Task ClientExistsAsyncShouldReturnExistingClient()
        {
            // Arrange
            var expectedClientUserId = "6d5800ced7264fc83d9d6b3ac1f591e";

            //Act
            var result = await clientService.ClientExistsAsync(expectedClientUserId);

            //Assert

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task GetAllClientsAsyncShouldReturnProperly()
        {
            //Act

            var list = await clientService.GetAllClientsAsync();

            //Assert

            Assert.That(list.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetClientByUserIdShouldReturnClient()
        {
            // Arrange
            var expectedClientUserId = "6d5800ced7264fc83d9d6b3ac1f591e";

            // Act

            var client = await clientService.GetClientEntityByUserIdAsync(expectedClientUserId);

            // Assert

            Assert.That(client, Is.Not.Null);
            Assert.That(client.UserId, Is.EqualTo(expectedClientUserId));
        }

        [Test]
        public async Task AddClientAsyncShouldAddANewClient()
        {
            //Arrange
            var ClientUserId = new Guid(Guid.NewGuid().ToString()).ToString();
            var clientName = "Toshko";

            //Act
            await clientService.AddClientAsync(ClientUserId, clientName,"","Larnaca","");
            var clients = await testRepository.AllReadOnly<Client>().ToListAsync();
            var clientsCount = clients.Count();
            var addedClient = await clientService.GetClientEntityByUserIdAsync(ClientUserId);

            //Assert
            Assert.That(addedClient.Name, Is.EqualTo(clientName));
            Assert.That(clientsCount, Is.EqualTo(2));
        }

        [Test]
        public async Task EditInfoAsyncShouldEditClientsInfo()
        {
            // Arrange
            var clientUserId = "6d5800ced7264fc83d9d6b3ac1f591e";
            var model = new ClientInfoForm()
            {
                ClientName = "Goshko",
                ClientCity = "Larnaca",
                ClientAddress = "",
                ClientPhoneNumber = "1234567890"
            };

            // Act

            await clientService.EditInfoAsync(clientUserId, model);

            Client client = await testRepository.All<Client>()
                .FirstAsync();

            // Assert
            Assert.That(client.Name, Is.EqualTo(model.ClientName));
        }

        [Test]
        public async Task GetClientInfoByUserIdShouldReturnClientsInfo()
        {
            // Arrange
            var clientUserId = "6d5800ced7264fc83d9d6b3ac1f591e";
            var name = "Pesho Petrov";

            //Act

            var model = await clientService.GetClientInfoByUserId(clientUserId);

            //Assert

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ClientInfo.Name, Is.EqualTo(name));
        }

        [Test]
        public async Task RemoveSpecialistFromClientShouldSetIsBusyToFalse()
        {
            // Arrange
            var clientUserId = "6d5800ced7264fc83d9d6b3ac1f591e";
            int specialistId = 1;
            
            var oldIsBusy = true;

            // Act
            
            var specialist = await testRepository.GetByIdAsync<Specialist>(specialistId);
            var newIsBusy = specialist.IsBusy;

            //Assert
            Assert.That(oldIsBusy, Is.Not.EqualTo(newIsBusy));

        }
    }
}
