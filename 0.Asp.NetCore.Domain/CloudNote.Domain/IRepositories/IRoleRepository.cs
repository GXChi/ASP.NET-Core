using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.IRepositories
{
    public interface IRoleRepository : IRepository<RoleEntity>
    {
        /// <summary>
        /// 根据角色获取权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        List<RoleAuthorityEntity> GetAuthorityListByRoleId(string roleId);

        /// <summary>
        /// 更新角色权限关联关系
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="roleAuthority">角色权限集合</param>
        /// <returns></returns>
        bool UpdateRoleAuthority(string roleId, List<RoleAuthorityEntity> roleAuthority);
    }
}
