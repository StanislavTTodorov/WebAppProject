using System.ComponentModel.DataAnnotations;
using static WebAppProject.Common.ModelsValidationConstants.Product;

namespace WebAppProject.Data.Models
{
    public class ProductModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), PriceMin, PriceMax)]
        public decimal Price { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
