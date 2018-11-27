using Domain.Common;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class TeachersRepository : DbRepository<Teacher>, ITeachersRepository
    {
        public TeachersRepository(DbContext context) : base(context)
        {
        }
    }
}
