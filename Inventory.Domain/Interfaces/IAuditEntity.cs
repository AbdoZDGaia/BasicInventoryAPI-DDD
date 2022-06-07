﻿namespace Inventory.Domain.Interfaces
{
    public interface IAuditEntity
    {
        DateTime CreatedDate { get; set; }
        string? CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string? UpdatedBy { get; set; }
    }
}
