using Domain.Entities;
using Domain.Common;
using Domain.Repositories;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class SpecialitiesRepository : DbRepository<Speciality>, ISpecialitiesRepository
    {
        public SpecialitiesRepository(DbContext context) : base(context)
        {
        }
    }
}
