using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class DatumRepository : RepositoryBase<DatumEntity>, IDatumRepository
    {
        public DatumRepository(CloudNoteDbContext dbContext) : base(dbContext)
        {

        }
    }
}
