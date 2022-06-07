using Inventory.Domain.Base;
using Inventory.Domain.Domains.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Inventory.Domain.Domains.ProductStatuses;

namespace Inventory.Domain.Domains.Products
{
    [Table("Products")]
    public partial class Product : AuditEntity<int>
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public string Barcode { get; set; }
        public int ProductStatusId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}