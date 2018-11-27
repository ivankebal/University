using Domain.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbGroups")]
    public class Group: DbEntity
    {
        [StringLength(64)]
        //[Index(IsUnique = true)]
        public string Name { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual List<Student> Students { get; set; }
        public List<AudLect> AudLects { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
