using Domain.Entities;
using Domain.Common;
using Domain.Repositories;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class MarksRepository : DbRepository<Mark>, IMarksRepository
    {
        public MarksRepository(DbContext context) : base(context)
        {
        }
    }
}
