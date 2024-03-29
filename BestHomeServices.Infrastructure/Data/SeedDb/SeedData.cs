using BestHomeServices.Infrastructure.Data.Models;

namespace BestHomeServices.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Category ElectricianCategory { get; set; }
        public Category PlumberCategory { get; set; }
        public Category HandymanCategory { get; set; }
        public City LarnacaCity { get; set; }
        public City PafosCity { get; set; }
        public City LimasolCity { get; set; }
        public Specialist FirstSpecialist { get; set; }
        public Specialist SecondSpecialist { get; set; }
        public Specialist ThirdSpecialist { get; set; }

        public SeedData()
        {
            SeedCategories();
            SeedCities();
            SeedSpecialists();
        }
      
        private void SeedCategories()
        {
            ElectricianCategory = new Category()
            {
                Id = 1,
                Title = "Electrician",
                Description = "Hire one of the most experienced electricians in your area.",
                ImgUrl = "~/images/electrical.png",
                Specialists = new List<Specialist>(),
            };

            PlumberCategory = new Category()
            {
                Id = 2,
                Title = "Plumber",               
                Description = "Hire one of the most experienced plumbers in your area.",
                ImgUrl = "~/images/plumber.png",
                Specialists = new List<Specialist>(),
            };

            HandymanCategory = new Category()
            {
                Id = 3,
                Title = "Handyman",
                Description = "Hire one of the most experienced handymen in your area.",
                ImgUrl = "~/images/handyman.png",
                Specialists = new List<Specialist>(),
            };
        }

        private void SeedCities()
        {
            LarnacaCity = new City()
            {
                Id = 1,
                Name = "Larnaca",
                //Categories = new List<Category>(), //{ ElectricianCategory, PlumberCategory, HandymanCategory },
                //Specialists = new List<Specialist>()
            };

            PafosCity = new City()
            {
                Id = 2,
                Name = "Pafos",
                //Categories = new List<Category>(), //{ ElectricianCategory, PlumberCategory},
                //Specialists = new List<Specialist>()
            };

            LimasolCity = new City()
            {
                Id = 3,
                Name = "Limasol",
                //Categories = new List<Category>(), //{ ElectricianCategory, HandymanCategory },
                //Specialists = new List<Specialist>()
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
                //Cities = new List<City>() { LarnacaCity, PafosCity, LimasolCity },
                ImageUrl = "https://media.istockphoto.com/id/516005348/photo/african-electrical-worker-using-laptop-computer.jpg?s=1024x1024&w=is&k=20&c=2wnW5I1-CWTKWB2GYpmgZ5X3oA2Etvq0e_1Tn3y9T6w=",
                Projects = new List<Project>()
            };

            SecondSpecialist = new Specialist()
            {
                Id = 2,
                CategoryId = PlumberCategory.Id,
                FirstName = "Pesho",
                LastName = "Peshev",
                Description = "This is one of the best plumbers in the area.",
                PhoneNumber = "0012233559",
                //Cities = new List<City>() { LarnacaCity, PafosCity },
                ImageUrl = "https://degraceplumbing.com/wp-content/uploads/2016/02/NJ-plumber-300x200.jpg",
                Projects = new List<Project>()
            };

            ThirdSpecialist = new Specialist()
            {
                Id = 3,
                CategoryId = HandymanCategory.Id,
                FirstName = "Stefka",
                LastName = "Zlateva",
                Description = "This is one of the best handymen in the area.",
                PhoneNumber = "0012233552",
                //Cities = new List<City>() { LarnacaCity, LimasolCity },
                ImageUrl = "https://image1.masterfile.com/getImage/NjAwLTA2NjcxNzUwZW4uMDAwMDAwMDA=AKvV1Y/600-06671750en_Masterfile.jpg",
                Projects = new List<Project>()
            };
        }
    }
}
