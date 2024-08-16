using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public class BaseEntity : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
