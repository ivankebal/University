using Domain.Entities;
using Domain.Common;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class PhonesRepository : DbRepository<Phone>, IPhonesRepository
    {
        public PhonesRepository(DbContext context) : base(context)
        {
        }
    }
}
