namespace Inventory.Domain.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int productId) :
            base($"Product with id: {productId} does not exist.")
        {

        }
    }
}
