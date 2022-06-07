namespace Inventory.Domain.Interfaces
{
    public interface IGenericAuditEntity<TKey> : IAuditEntity, IGenericDeleteEntity<TKey>
    {
    }
}
