using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class RoleRepository : RepositoryBase<RoleEntity>,IRoleRepository
    {
        public RoleRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
