using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class RoleRepository : RepositoryBase<RoleEntity>,IRoleRepository
    {
        
        public RoleRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }

        /// <summary>
        /// 根据角色获取权限
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        public List<RoleAuthorityEntity> GetAuthorityListByRoleId(string roleId)
        {
            return _dbContext.Set<RoleAuthorityEntity>().Where(x => x.RoleId == roleId).ToList();
        }

        /// <summary>
        /// 更新角色权限关联关系
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="roleAuthority">角色权限集合</param>
        /// <returns></returns>
        public bool UpdateRoleAuthority(string roleId, List<RoleAuthorityEntity> roleAuthority)
        {
            //var oldDatas = _dbContext.Set<RoleAuthorityEntity>().Where(it => it.RoleId == roleId).ToList();
            //foreach (var item in roleAuthority)
            //{
            //    var index = oldDatas.FindIndex(x => x.AuthorityId == item.AuthorityId);
            //    if (index == -1)
            //    {
            //        oldDatas.Add(item);
            //    }
            //}
            _dbContext.UpdateRange(roleAuthority);
            return true;
        }
    }
}
