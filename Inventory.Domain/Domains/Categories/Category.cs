using Inventory.Domain.Base;
using Inventory.Domain.Domains.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Domain.Domains.Categories
{
    [Table("Categories")]
    public partial class Category : DeleteEntity<int>
    {
        [Required]
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

    }
}
