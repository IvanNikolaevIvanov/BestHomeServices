using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Enumerations;

namespace BestHomeServices.Core.Models.Home
{
    public class AllCategoriesIndexServiceModel
    {
        public string Category { get; set; } = null!;

        public CityEnumeration Cities { get; init; } 

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

    }
}
