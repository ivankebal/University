using Domain.Entities;
using Domain.Common;
using Domain.Repositories;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class TeachSubjRepository : DbRepository<TeachSubj>, ITeachSubjRepository
    {
        public TeachSubjRepository(DbContext context) : base(context)
        {
        }
    }
}
