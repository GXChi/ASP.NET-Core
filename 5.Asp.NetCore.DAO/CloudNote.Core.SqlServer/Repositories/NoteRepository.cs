using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class NoteRepository : RepositoryBase<NoteEntity>,INoteRepository
    {
        public NoteRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
