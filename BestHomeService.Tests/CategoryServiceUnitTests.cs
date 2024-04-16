using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Enumerations;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Services;
using NUnit.Framework.Internal;

namespace BestHomeServices.UnitTests
{
    [TestFixture]
    public class CategoryServiceUnitTests : UnitTestsBase
    {
        protected ICategoryService categoryService;
       
        [SetUp]
        public void SetUp()
        {
            categoryService = new CategoryService(repository);
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
            Assert.That(resultOne, Is.EqualTo(true));
            Assert.That(resultTwo, Is.EqualTo(false));
        }


        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategoriesIfNoFiltering()
        {
            // Act
            var categories = await categoryService.AllCategoriesAsync();


            // Assert
            Assert.IsNotNull(categories);
            Assert.That(categories.Count(), Is.EqualTo(3));

        }

        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategoriesIfOnlyCategoryName()
        {
            // Act
            var categories = await categoryService.AllCategoriesAsync(0, "Electrician");


            // Assert
            Assert.IsNotNull(categories);
            Assert.That(categories.Count(), Is.EqualTo(1));

        }

        [Test]
        public async Task AllCategoriesAsyncShouldReturnAllCategoriesIfOnlyCityName()
        {
            // Act
            var categories = await categoryService.AllCategoriesAsync(CityEnumeration.Larnaca, null);


            // Assert
            Assert.IsNotNull(categories);
            Assert.That(categories.Count(), Is.EqualTo(2));

        }

        [Test]
        public async Task CategoryDetailsByIdAsyncShouldReturnByExistingCategoryId()
        {
            //Act
            var category = await categoryService.CategoryDetailsByIdAsync(1);

            //Assert
            Assert.IsNotNull(categories);
            Assert.That(category.Specialists.Count(), Is.EqualTo(1));
            
        }

        [Test]
        public async Task AddCategoryAsyncShouldAddANewCategory()
        {
            //Arrange
            CategoryFormModel newCategory = new CategoryFormModel()
            {
                Title = "Test",
                Description = "Test",
                ImgUrl = "test"
                 
            };

            // Act
            await categoryService.AddCategoryAsync(newCategory);

            var categories = await categoryService.AllCategoriesAsync();

            // Assert
            
            Assert.That(categories.Count(), Is.EqualTo(4));

        }

        [Test]
        public async Task DeleteCategoryAsyncShouldDeleteExistingCategoryWithNoSpecialistRelations()
        {
            // Arrange
            CategoryFormModel newCategory = new CategoryFormModel()
            {
                Title = "Test",
                Description = "Test",
                ImgUrl = "test"

            };
            await categoryService.AddCategoryAsync(newCategory);

            var categoriesBeforeDelete = await categoryService.AllCategoriesAsync();

            // Act

            await categoryService.DeleteCategoryAsync(4);

            var categoriesAfterDelete = await categoryService.AllCategoriesAsync();

            // Assert

            Assert.That(categoriesBeforeDelete.Count(), Is.EqualTo(categoriesAfterDelete.Count() + 1));
        }


        [Test]
        public async Task EditAsyncShouldEditAnExistingAnCategoryWithAccurateData()
        {
            // Arrange
            CategoryDetailsViewModel model = new CategoryDetailsViewModel()
            {
                Title = "Test"
            };

            // Act

            await categoryService.EditAsync(1, model);
            var categories = await categoryService.AllCategoriesAsync(0, "Test");
            var category = categories.First();

            // Assert

            Assert.That(model.Title, Is.EqualTo(category.Title));
        }

        [Test]
        public async Task GetCategoryFormByIdAsyncReturnsModelOfExistingCategory()
        {
            // Arrange
            CategoryFormModel model = new CategoryFormModel()
            {
                Title = "Electrician"
            };

            // Act

            var returnedModel = await categoryService.GetCategoryFormByIdAsync(1);

            // Assert

            Assert.That(returnedModel.Title, Is.EqualTo(model.Title));
        }

    } 
}
