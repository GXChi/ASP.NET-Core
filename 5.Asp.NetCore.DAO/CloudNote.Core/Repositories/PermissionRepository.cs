using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class PermissionRepository : RepositoryBase<PermissionEntity>,IPermissionRepository
    {
        public PermissionRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
