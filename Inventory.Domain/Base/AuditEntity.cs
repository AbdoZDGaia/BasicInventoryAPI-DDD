using Inventory.Domain.Interfaces;

namespace Inventory.Domain.Base
{
    public abstract class AuditEntity<TKey> : DeleteEntity<TKey>, IGenericAuditEntity<TKey>
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
