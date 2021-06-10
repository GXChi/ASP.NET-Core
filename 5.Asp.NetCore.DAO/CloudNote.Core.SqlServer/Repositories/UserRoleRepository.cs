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


        /// <summary>
        /// 给用户分配角色
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userRole">用户角色权集合</param>
        /// <returns></returns>
        public bool SetRole(string userId, List<UserRoleEntity> userRole)
        {
            var oldUserRoleData = _dbContext.Set<UserRoleEntity>().Where(x => x.UserId == userId).ToList();
            //oldUserRoleData.ForEach(it => _dbContext.Set<UserRoleEntity>().Remove(it));
            _dbContext.Set<UserRoleEntity>().RemoveRange(oldUserRoleData);
            _dbContext.SaveChanges();
            _dbContext.Set<UserRoleEntity>().AddRange(userRole);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
