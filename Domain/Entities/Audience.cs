using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbAudiences")]
    public class Audience: DbEntity
    {
        [StringLength(32)]
        public string Name { get; set; }
        public List<AudLect> AudLects { get; set; }
    }
}
