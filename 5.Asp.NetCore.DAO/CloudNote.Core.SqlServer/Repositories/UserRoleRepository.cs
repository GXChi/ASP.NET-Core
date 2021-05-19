using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRoleEntity>, IUserRoleRepository
    {
        public UserRoleRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
