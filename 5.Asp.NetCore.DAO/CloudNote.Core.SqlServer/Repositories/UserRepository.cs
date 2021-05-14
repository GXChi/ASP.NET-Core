using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using System;
using System.Linq;

namespace CloudNote.Core.SqlServer.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>,IUserRepository
    {
        public UserRepository(CloudNoteDbContext dbContext) : base(dbContext)
        { }

        /// <summary>
        /// 根据用户名和密码检测用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns>存在返回用户实体，否则返回null</returns>
        public UserEntity CheckUser(string userName, string passWord)
        {
            return _dbContext.Set<UserEntity>().FirstOrDefault(x => x.UserName == userName && x.PassWord == passWord);
        }

        /// <summary>
        /// 根据用户ID获取用户(角色)
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>返回用户实体</returns>
        public UserEntity GetRolesByUserId(Guid id)
        {
            var user = _dbContext.Set<UserEntity>().FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                user.UserRoles = _dbContext.Set<UserRoleEntity>().Where(x => x.UserId == id.ToString()).ToList();
            }
            return user;
        }
    }
}
