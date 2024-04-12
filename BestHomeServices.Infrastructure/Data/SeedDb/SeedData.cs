using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BestHomeServices.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser AdminUser { get; set; }
        public IdentityUser ClientUser { get; set; }
        public Category ElectricianCategory { get; set; }
        public Category PlumberCategory { get; set; }
        public Category HandymanCategory { get; set; }
        public City LarnacaCity { get; set; }
        public City PafosCity { get; set; }
        public City LimasolCity { get; set; }
        public Specialist FirstSpecialist { get; set; }
        public Specialist SecondSpecialist { get; set; }
        public Specialist ThirdSpecialist { get; set; }
        public Client FirstClient { get; set; }
        public Project FirstProject { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedCategories();
            SeedCities();
            SeedClient();
            SeedSpecialists();
            SeedProjects();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new IdentityUser()
            {
                Id = "c5b3928f-781a-4d2b-88c5-c6a10572e32b",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                EmailConfirmed = true
            };

            AdminUser.PasswordHash =
                hasher.HashPassword(AdminUser, "admin123");

            ClientUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "client@mail.com",
                NormalizedUserName = "CLIENT@MAIL.COM",
                Email = "client@mail.com",
                NormalizedEmail = "CLIENT@MAIL.COM",
                EmailConfirmed = true
            };

            ClientUser.PasswordHash =
            hasher.HashPassword(ClientUser, "client123");
        }

        private void SeedCities()
        {
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
        }

        private void SeedCategories()
        {
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
        }

        

        private void SeedClient()
        {
            FirstClient = new Client()
            {
                Id = 1,
                Name = "Pesho Petrov",
                Address = "16 Pythagorou str",
                CityId = 1,
                PhoneNumber = "0035799344556",
                UserId = ClientUser.Id
            };
        }

        private void SeedSpecialists()
        {
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


        }

        private void SeedProjects()
        {
            FirstProject = new Project()
            {
                ClientId = FirstClient.Id,
                SpecialistId = FirstSpecialist.Id,
            };
        }
    }
}
