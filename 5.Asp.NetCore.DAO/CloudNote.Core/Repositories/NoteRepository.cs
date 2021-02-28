using CloudNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class NoteRepository : RepositoryBase<NoteEntity>
    {
        public NoteRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
