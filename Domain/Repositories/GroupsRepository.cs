using Domain.Entities;
using Domain.Common;
using System.Data.Entity;

namespace Domain.Repositories
{
    public class GroupsRepository : DbRepository<Group>, IGroupsRepository
    {
        public GroupsRepository(DbContext context) : base(context)
        {
        }
    }
}
