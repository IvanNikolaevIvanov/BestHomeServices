using BestHomeServices.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Contracts
{
    public interface ISpecialistService
    {
        Task HireSpecialistByIdAsync(int id);
    }
}
