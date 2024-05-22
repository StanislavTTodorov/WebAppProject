using System.ComponentModel.DataAnnotations;
using static WebAppProject.Common.ModelsValidationConstants.Product;

namespace WebAppProject.ViewModels.Product
{
    public class ProductDisplayModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Range(typeof(decimal), PriceMin, PriceMax)]
        public decimal Price { get; set; }

        //public string DateAdded { get; set; }
    }
}
