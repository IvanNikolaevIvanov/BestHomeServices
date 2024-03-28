using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BestHomeServices.Infrastructure.Constants.DataConstants;

namespace BestHomeServices.Infrastructure.Data.Models
{
    [Comment("Cities in which service is provided")]
    public class City
    {
        [Key]
        [Comment("City's identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CityNameMaxLength)]
        [Comment("City's Name")]
        public string Name { get; set; } = string.Empty;

        [Comment("List of categories available in the city")]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Comment("List of specialist operating in the area")]
        public ICollection<Specialist> Specialists { get; set; } = new List<Specialist>();
    }
}
