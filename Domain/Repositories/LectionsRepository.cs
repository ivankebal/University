using Domain.Entities;
using Domain.Common;
using Domain.Repositories;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class LectionsRepository : DbRepository<Lection>, ILectionsRepository
    {
        public LectionsRepository(DbContext context) : base(context)
        {
        }
    }
}
