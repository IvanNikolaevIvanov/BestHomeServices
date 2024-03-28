using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BestHomeServices.Infrastructure.Constants.DataConstants;


namespace BestHomeServices.Infrastructure.Data.Models
{
    [Comment("Home Service Category")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryTitleMaxLength)]
        [Comment("Category's Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(CategoryDescriptionMaxLength)]
        [Comment("Category's Short Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(CategoryImageUrlMaxLength)]
        [Comment("Category's Image")]
        public string ImgUrl { get; set; } = string.Empty;

        [Comment("List of cities in which the service is provided")]
        public ICollection<City> Cities { get; set; } = new List<City>();

        [Comment("List of specialists who provide the service")]
        public ICollection<Specialist> Specialists { get; set; } = new List<Specialist>();
    }
}
