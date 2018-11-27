using System.ComponentModel.DataAnnotations;

namespace Domain.Abstract
{
    public interface IDbEntity
    {
        [Key]
        int Id { get; set; }
    }
}
