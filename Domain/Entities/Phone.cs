using Domain.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbPhones")]
    public class Phone: DbEntity
    {
        [StringLength(64)]
        public string StudentsPhone { get; set; }
        public virtual Student Student { get; set; }
    }
}
