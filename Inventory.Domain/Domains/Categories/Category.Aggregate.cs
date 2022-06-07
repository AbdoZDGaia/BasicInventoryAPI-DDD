namespace Inventory.Domain.Domains.Categories
{
    public partial class Category
    {
        public Category(string categoryName) : base()
        {
            CategoryName = categoryName;
        }

        public bool ValidOnAdd()
        {
            return
                // Validate userName
                !string.IsNullOrEmpty(CategoryName);
        }
    }
}
