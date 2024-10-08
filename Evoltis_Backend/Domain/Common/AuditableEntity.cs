﻿namespace Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AuditableEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
