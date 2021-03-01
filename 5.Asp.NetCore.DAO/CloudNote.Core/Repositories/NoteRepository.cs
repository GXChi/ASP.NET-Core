using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class NoteRepository : RepositoryBase<NoteEntity>,INoteRepository
    {
        public NoteRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
