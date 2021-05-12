using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class AuthorityRepository : RepositoryBase<AuthorityEntity>, IAuthorityRepository
    {
        public AuthorityRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
