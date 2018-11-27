using Domain.Entities;
using Domain.Common;
using Domain.Repositories;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class AudiencesRepository : DbRepository<Audience>, IAudiencesRepository
    {
        public AudiencesRepository(DbContext context) : base(context)
        {
        }
    }
}
