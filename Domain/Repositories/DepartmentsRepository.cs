using Domain.Common;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class DepartmentsRepository: DbRepository<Department>, IDepartmentsRepository
    {
        public DepartmentsRepository(DbContext context) : base(context)
        {

        }
    }
}
