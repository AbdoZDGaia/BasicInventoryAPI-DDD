using Inventory.Domain.Interfaces;

namespace Inventory.Domain.Domains.Categories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category NewCategory(string categoryName);
    }
}
