using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbMarks")]
    public class Mark: DbEntity
    {
        [Range(0,100)]
        public int StudentsMark { get; set; }
        public virtual Student Student { get; set; }
        public virtual TeachSubj TeachSubj { get; set; }

    }
}
