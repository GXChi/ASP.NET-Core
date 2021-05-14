using CloudNote.Domain.Entities.Areas;
using System;

namespace CloudNote.Domain.IRepositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        /// <summary>
        /// 根据用户名和密码检测用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns>存在返回用户实体，否则返回null</returns>
        UserEntity CheckUser(string userName, string passWord);

        /// <summary>
        /// 根据用户ID获取用户(角色)
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>返回用户实体</returns>
        UserEntity GetRolesByUserId(Guid id);
    }
}
