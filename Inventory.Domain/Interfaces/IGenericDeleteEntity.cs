namespace Inventory.Domain.Interfaces
{
    public interface IGenericDeleteEntity<TKey> : IDeleteEntity, IEntityBase<TKey>
    {
    }
}
