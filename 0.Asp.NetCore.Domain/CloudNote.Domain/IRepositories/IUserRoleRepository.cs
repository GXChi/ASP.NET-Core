using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.IRepositories
{
    public interface IUserRoleRepository : IRepository<UserRoleEntity>
    {

        /// <summary>
        /// 给用户分配角色
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userRole">用户角色权集合</param>
        /// <returns></returns>
        bool SetRole(string userId, List<UserRoleEntity> userRole);
    }
}
