using Inventory.Domain.Base;
using Inventory.Domain.Domains.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Domain.Domains.ProductStatuses
{
    [Table("ProductStatuses")]
    public partial class ProductStatus : DeleteEntity<int>
    {
        [Required]
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public List<Product> Products { get; set; }
    }
}
