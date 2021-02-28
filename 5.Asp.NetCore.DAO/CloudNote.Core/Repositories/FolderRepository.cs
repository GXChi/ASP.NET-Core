using CloudNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class FolderRepository : RepositoryBase<FolderEntity>
    {
        public FolderRepository(CloudNoteDbContext dbContext) : base(dbContext)
        {

        }
    }
}
