using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbStudents")]
    public class Student: DbEntity
    {
        [StringLength(64)]
        public string FirstName { get; set; }
        [StringLength(64)]
        public string MiddleName { get; set; }
        [StringLength(64)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Birthday { get; set; }
        //[Index(IsUnique = true)]
        public int LogbookNumber { get; set; }
        [StringLength(64)]
        public string Email { get; set; }
        [StringLength(128)]
        public string Address { get; set; }
        public virtual List<Phone> Phones { get; set; }
        public virtual Group Group { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName} {Group} {LogbookNumber}";
        }
    }
}
