namespace Inventory.Domain.Domains.ProductStatuses
{
    public partial class ProductStatus
    {
        public ProductStatus(string statusName) : base()
        {
            StatusName = statusName;
        }

        public bool ValidOnAdd()
        {
            return !string.IsNullOrEmpty(StatusName);
        }
    }
}
