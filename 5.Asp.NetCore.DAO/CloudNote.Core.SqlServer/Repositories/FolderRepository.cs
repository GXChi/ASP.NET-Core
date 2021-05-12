using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class FolderRepository : RepositoryBase<FolderEntity>, IFolderRepository
    {
        public FolderRepository(CloudNoteDbContext dbContext) : base(dbContext)
        {

        }
    }
}
