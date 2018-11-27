using Domain.Entities;
using Domain.Common;
using Domain.Repositories;
using System.Data.Entity;

namespace Domain.Repositories 
{
    public class SubjectsRepository : DbRepository<Subject>, ISubjectsRepository
    {
        public SubjectsRepository(DbContext context) : base(context)
        {

        }
    }
}
