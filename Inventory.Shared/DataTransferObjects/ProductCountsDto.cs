namespace Inventory.Shared.DataTransferObjects
{
    public record ProductCountsDto
    {
        public int Damaged { get; init; }
        public int InStock { get; init; }
        public int Sold { get; init; }
    }
}