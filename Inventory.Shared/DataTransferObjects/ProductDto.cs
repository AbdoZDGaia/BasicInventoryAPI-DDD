namespace Inventory.Shared.DataTransferObjects
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string ProductName { get; init; }
        public string Barcode { get; init; }
        public decimal Weight { get; init; }
        public string Description { get; init; }
        public string ProductStatus { get; init; }
        public string CategoryName { get; init; }
    }
}
