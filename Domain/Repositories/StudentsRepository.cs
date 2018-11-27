using Domain.Entities;
using Domain.Common;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class StudentsRepository : DbRepository<Student>, IStudentsRepository
    {
        public StudentsRepository(DbContext context) : base(context)
        {
        }
    }
}
