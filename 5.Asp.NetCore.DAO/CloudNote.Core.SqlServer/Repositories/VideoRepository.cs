using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class VideoRepository : RepositoryBase<VideoEntity>, IVideoRepository
    {
        public VideoRepository(CloudNoteDbContext dbContext) : base(dbContext)
        {

        }
    }
}
