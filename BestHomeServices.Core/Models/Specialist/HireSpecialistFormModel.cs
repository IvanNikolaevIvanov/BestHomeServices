using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Models.Specialist
{
    public class HireSpecialistFormModel
    {
        public int SpecialistId { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public string ClientCity { get; set; } = string.Empty;

        public string ClientAddress { get; set; } = string.Empty;

        [Display(Name = "Phone number")]
        public string ClientPhoneNumber { get; set; } = string.Empty;

    }
}
