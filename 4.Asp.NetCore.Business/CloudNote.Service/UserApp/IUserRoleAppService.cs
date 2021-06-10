using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.UserApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.UserApp
{
    public interface IUserRoleAppService
    {
        public List<UserRoleDto> GetAllList(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order);

        List<UserRoleDto> GetAllList(Expression<Func<UserEntity, bool>> where);

        UserRoleDto GetUserById(Guid id);

        bool InsertOrUpdate(UserRoleDto entity);

        void Delete(Guid id);

        void DeleteBatch(List<Guid> ids);

        bool SetRole(string userId, List<UserRoleDto> userRole);

        //List<UserDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order);

    }
}
