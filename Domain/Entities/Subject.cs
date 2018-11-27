using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbSubjects")]
    public class Subject: DbEntity
    {
        [StringLength(64)]
        public string Name { get; set; }
        public IList<TeachSubj> TeachSubj { get; set; }
    }
}
