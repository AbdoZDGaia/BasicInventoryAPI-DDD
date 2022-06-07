using Inventory.Domain.Interfaces;

namespace Inventory.Domain.Base
{
    public abstract class DeleteEntity<TKey> : EntityBase<TKey>, IGenericDeleteEntity<TKey>
    {
        public bool IsDeleted { get; set; }
    }
}
