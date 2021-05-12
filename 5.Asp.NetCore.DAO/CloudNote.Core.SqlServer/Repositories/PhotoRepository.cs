using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class PhotoRepository : RepositoryBase<PhotoEntity>, IPhotoRepository
    {
        public PhotoRepository(CloudNoteDbContext dbContext) : base(dbContext)
        {

        }
    }
}
