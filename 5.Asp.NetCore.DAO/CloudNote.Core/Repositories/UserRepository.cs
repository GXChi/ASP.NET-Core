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
    public class UserRepository : RepositoryBase<UserEntity>,IUserRepository
    {
        public UserRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }
    }
}
