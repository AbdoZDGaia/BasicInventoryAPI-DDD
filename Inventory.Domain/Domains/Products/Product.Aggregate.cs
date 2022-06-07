namespace Inventory.Domain.Domains.Products
{
    public partial class Product
    {
        public Product(string productName, string barcode, string description, decimal weight, int productStatusId) : base()
        {
            ProductName = productName;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            ProductStatusId = productStatusId;
        }

        public Product()
        {

        }

        public bool ValidOnAdd()
        {
            return !(string.IsNullOrEmpty(ProductName) ||
                string.IsNullOrEmpty(Barcode) ||
                Weight <= 0);
        }
    }
}
