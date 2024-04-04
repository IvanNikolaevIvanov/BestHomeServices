using BestHomeServices.Core.Models.Category;

namespace BestHomeServices.Core.Models.Home
{
    public class AllCategoriesIndexServiceModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

    }
}
