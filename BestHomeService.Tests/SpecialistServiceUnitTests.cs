using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Core.Services;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;

namespace BestHomeServices.UnitTests
{
    [TestFixture]
    public class SpecialistServiceUnitTests : UnitTestsBase
    {
        private SpecialistService specialistService;
        private Specialist testSpecialist;
        private IRepository testRepository;

        [SetUp]
        public void SetUp()
        {
            specialistService = new SpecialistService(repository);
            testSpecialist = SecondSpecialist;
            testRepository = repository;
        }

        [Test]
        public async Task SpecialistExistsAsyncShouldReturnSpecialistByExistingId()
        {
            // Arrange

            var expectedResult = true;
            
            // Act

            var result = await specialistService.SpecialistExistsAsync(1);

            // Assert

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task HireSpecialistByIdAsyncShouldCreateANewProject()
        {
            // Arrange
            Client client = new Client()
            {
                Id = 2,
                Name = "TestClient",
                PhoneNumber = "1234567890",
            };

            // Act

            await specialistService.HireSpecialistByIdAsync(testSpecialist, client);

            int projectsCount = testRepository.AllReadOnly<Project>().Count();

            // Assert

            Assert.That(projectsCount, Is.EqualTo(2));
            Assert.That(testSpecialist.IsBusy, Is.EqualTo(true));
        }

        [Test]
        public async Task GetSpecialistByIdAsyncShouldReturnExistingSpecialist()
        {
            // Act 
            var currentSpecialist = await specialistService.GetSpecialistByIdAsync(1);

            // Assert 
            Assert.That(currentSpecialist, Is.Not.Null);
            Assert.That(currentSpecialist.FirstName, Is.EqualTo("Ivan"));
        }

        [Test]
        public async Task GetAllSpecialistsAsyncShouldReturnAllSpecialists()
        {
            //Act

            var list = await specialistService.GetAllSpecialistsAsync();

            //Assert

            Assert.That(list.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task AddSpecialistAsyncShouldAddSpecialist()
        {
            // Arrange

            var testSpecialist = new AddSpecialistFormModel()
            {
                FirstName = "Test",
                LastName = "Specialist",
                PhoneNumber = "1234567890",
            };

            // Act
            int specialistsOldCount = testRepository.AllReadOnly<Specialist>().Count();

            await specialistService.AddSpecialistAsync(testSpecialist);

            int specialistsNewCount = testRepository.AllReadOnly<Specialist>().Count();
            // Assert

            Assert.That(specialistsNewCount, Is.EqualTo(specialistsOldCount + 1));
        }

        [Test]
        public async Task DeleteSpecialistAsyncShouldDeleteSpecialistWithNoRelations()
        {
            // Arrange
            var testSpecialist = new AddSpecialistFormModel()
            {
                FirstName = "Test",
                LastName = "Specialist",
                PhoneNumber = "1234567890",
            };

            await specialistService.AddSpecialistAsync(testSpecialist);

            int specialistsOldCount = testRepository.AllReadOnly<Specialist>().Count();

            // Act

            await specialistService.DeleteSpecialistAsync(3);

            int specialistsNewCount = testRepository.AllReadOnly<Specialist>().Count();

            // Assert

            Assert.That(specialistsNewCount, Is.EqualTo(specialistsOldCount - 1));

        }

        [Test]
        public async Task GetSpecialistFormByIdAsyncShouldReturnSpecialist()
        {
            // Act

            var model = await specialistService.GetSpecialistFormByIdAsync(1);

            // Assert

            Assert.That(model, Is.Not.Null);
            Assert.That(model.FirstName, Is.EqualTo("Ivan"));
        }
        [Test]
        public async Task IsSpecialistsAPartOfProjectAsyncShouldReturnTrue()
        {
            // Act

            var resultTrue = await specialistService.IsSpecialistsAPartOfProjectAsync(1);

            var resultFalse = await specialistService.IsSpecialistsAPartOfProjectAsync(2);

            // Assert

            Assert.That(resultTrue, Is.True);
            Assert.That(resultFalse, Is.EqualTo(false));
        }

        [Test]
        public async Task EditSpecialistAsyncShouldEditSpecialist()
        {
            // Arrange
            var testSpecialist = new AddSpecialistFormModel()
            {
                FirstName = "Test",
                LastName = "Specialist",
                PhoneNumber = "1234567890",
            };

            // Act

            await specialistService.EditSpecialistAsync(1, testSpecialist);

            var editedSpecialist = await testRepository.GetByIdAsync<Specialist>(1);
            //Assert

            Assert.That(editedSpecialist.FirstName, Is.EqualTo("Test"));

        }


    }
}
