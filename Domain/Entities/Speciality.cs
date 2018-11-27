using Domain.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("tbSpeciality")]
    public class Speciality : DbEntity
    {
        [StringLength(64)]
        public string Name { get; set; }
        public virtual List<Group> Groups { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
