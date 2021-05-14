using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.UserApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.UserApp
{
    public interface IUserAppService
    {
        UserDto CheckUser(string userName, string passWord);
        List<UserDto> GetAllList();

        List<UserDto> GetAllList(Expression<Func<UserEntity, bool>> where);

        UserDto GetUserById(Guid id);

        UserDto InsertOrUpdate(UserEntity entity);
        void Delete(Guid id);

        void DeleteBatch(List<Guid> ids);

        //List<UserDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order);

    }
}
