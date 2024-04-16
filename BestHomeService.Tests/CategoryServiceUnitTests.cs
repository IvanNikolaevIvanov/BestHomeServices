using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Services;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;
using BestHomeServices.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.UnitTests
{
    [TestFixture]
    public class CategoryServiceUnitTests
    {

        protected BestHomeServicesDb _data;
        protected IRepository repository;

        protected ICategoryService categoryService;
        protected IEnumerable<Category> categories;
        protected IEnumerable<Specialist> specialists;
        protected IEnumerable<City> cities;
        public Category ElectricianCategory;
        public Category PlumberCategory;
        public Category HandymanCategory;

        public City LarnacaCity;
        public City PafosCity;
        public City LimasolCity;

        public Specialist FirstSpecialist;
        public Specialist SecondSpecialist;
        public Specialist ThirdSpecialist;

        public Client FirstClient;
        public Project FirstProject;


        [SetUp]
        public void Setup()
        {
            // categories

            ElectricianCategory = new Category()
            {
                Id = 1,
                Title = "Electrician",
                Description = "Hire one of the most experienced electricians in your area.",
                ImgUrl = "images/electrical.png",

            };

            PlumberCategory = new Category()
            {
                Id = 2,
                Title = "Plumber",
                Description = "Hire one of the most experienced plumbers in your area.",
                ImgUrl = "images/plumber.png"
            };

            HandymanCategory = new Category()
            {
                Id = 3,
                Title = "Handyman",
                Description = "Hire one of the most experienced handymen in your area.",
                ImgUrl = "images/handyman.png"
            };

            //cities

            LarnacaCity = new City()
            {
                Id = 1,
                Name = "Larnaca"

            };

            PafosCity = new City()
            {
                Id = 2,
                Name = "Pafos"

            };

            LimasolCity = new City()
            {
                Id = 3,
                Name = "Limasol"

            };

            // specialists

            FirstSpecialist = new Specialist()
            {
                Id = 1,
                CategoryId = ElectricianCategory.Id,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Description = "This is one of the best electricians in the area.",
                PhoneNumber = "0012233556",
                CityId = 1,
                ImageUrl = "https://media.istockphoto.com/id/516005348/photo/african-electrical-worker-using-laptop-computer.jpg?s=1024x1024&w=is&k=20&c=2wnW5I1-CWTKWB2GYpmgZ5X3oA2Etvq0e_1Tn3y9T6w=",

            };

            SecondSpecialist = new Specialist()
            {
                Id = 2,
                CategoryId = PlumberCategory.Id,
                FirstName = "Pesho",
                LastName = "Peshev",
                Description = "This is one of the best plumbers in the area.",
                PhoneNumber = "0012233559",
                CityId = 1,
                ImageUrl = "https://degraceplumbing.com/wp-content/uploads/2016/02/NJ-plumber-300x200.jpg",

            };

            ThirdSpecialist = new Specialist()
            {
                Id = 3,
                CategoryId = HandymanCategory.Id,
                FirstName = "Stefka",
                LastName = "Zlateva",
                Description = "This is one of the best handymen in the area.",
                PhoneNumber = "0012233552",
                CityId = 2,
                ImageUrl = "https://image1.masterfile.com/getImage/NjAwLTA2NjcxNzUwZW4uMDAwMDAwMDA=AKvV1Y/600-06671750en_Masterfile.jpg",

            };

            FirstClient = new Client()
            {
                Id = 1,
                Name = "Pesho Petrov",
                Address = "16 Pythagorou str",
                CityId = 1,
                PhoneNumber = "0035799344556",
                UserId = "6d5800ced7264fc83d9d6b3ac1f591e"
            };

            FirstProject = new Project()
            {
                ClientId = 1,
                SpecialistId = 1,
            };

            specialists = new List<Specialist>()
            {
                 FirstSpecialist, SecondSpecialist, ThirdSpecialist
            };

            cities = new List<City>()
            {
                LarnacaCity, PafosCity, LimasolCity
            };

            categories = new List<Category>()
            {
                ElectricianCategory, PlumberCategory, HandymanCategory
            };

            // Database

            var options = new DbContextOptionsBuilder<BestHomeServicesDb>()
                .UseInMemoryDatabase(databaseName: "BestHomeServicesDb" + Guid.NewGuid().ToString())
                .Options;

            _data = new BestHomeServicesDb(options);
           

            _data.Categories.AddRangeAsync(categories);
            _data.Specialists.AddRangeAsync(specialists);
            _data.Cities.AddRangeAsync(cities);
            _data.AddAsync(FirstClient);
            _data.AddAsync(FirstProject);
            _data.SaveChanges();


            repository = new Repository(_data);

            categoryService = new CategoryService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this._data.Database.EnsureDeletedAsync();
            await this._data.DisposeAsync();
        }


        [Test]
        public async Task ExistsAsyncShouldReturnTrue()
        {
            //Arrange
            int categoryId = 1;
            int nonExistingCategoryId = -1;

            // Act
            var resultOne = await categoryService.ExistsAsync(categoryId);
            var resultTwo = await categoryService.ExistsAsync(nonExistingCategoryId);

            // Assert
            Assert.AreEqual(true, resultOne);
            Assert.AreEqual(false, resultTwo);
        }


        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategories()
        {

        }
    }
}
