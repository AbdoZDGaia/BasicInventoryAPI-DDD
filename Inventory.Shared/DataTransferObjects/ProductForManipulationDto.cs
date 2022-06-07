using System.ComponentModel.DataAnnotations;

namespace Inventory.Shared.DataTransferObjects
{
    public record ProductForManipulationDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MinLength(3, ErrorMessage = "Product name is too short")]
        public string ProductName { get; init; }
        
        [Required(ErrorMessage = "Product Barcode is required")]
        [MinLength(3, ErrorMessage = "Product Barcode is too short")]
        public string Barcode { get; init; }

        [Required(ErrorMessage = "Product Weight is required")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999.99)]
        public decimal Weight { get; init; }

        [Required(ErrorMessage = "Product Description is required")]
        [MinLength(3, ErrorMessage = "Product Description is too short")]
        public string Description { get; init; }
        
        [Range(0,99,ErrorMessage ="Invalid Status Id")]
        public int ProductStatusId { get; init; }
        
        [Range(0,99,ErrorMessage ="Invalid Category Id")]
        public int CategoryId { get; init; }
    }
}
