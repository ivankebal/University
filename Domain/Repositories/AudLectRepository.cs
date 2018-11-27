using Domain.Entities;
using Domain.Common;
using Domain.Repositories;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class AudLectRepository : DbRepository<AudLect>, IAudLectRepository
    {
        public AudLectRepository(DbContext context) : base(context)
        {
        }
    }
}
