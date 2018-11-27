using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbTeachSubj")]
    public class TeachSubj: DbEntity
    {
        public int TeacherId { get; set; }
        public int SubjId { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public virtual List<Mark> Marks { get; set; }
        public virtual List<AudLect> AudLects { get; set; }
    }
}
