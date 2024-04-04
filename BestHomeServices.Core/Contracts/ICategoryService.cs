﻿using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Home;

namespace BestHomeServices.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategories();
        
    }
}
