using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbAudLect")]
    public class AudLect: DbEntity
    {
        public int AudId { get; set; }
        public int LectId { get; set; }
        public int GroupId { get; set; }
        public Audience Audience { get; set; }
        public Lection Lection { get; set; }
        public Group Group { get; set; }
        public virtual TeachSubj TeachSubj { get; set; }
    }
}
