using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>,IUserRepository
    {
        public UserRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
