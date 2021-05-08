using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.NoteApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CloudNote.Service.NoteApp
{
    public interface IUserAppService
    {
        UserDto Insert(UserEntity dto);

        List<UserDto> GetAll();

        List<UserDto> GetAllList(Expression<Func<UserEntity, bool>> where);

        UserDto Get(Guid id);

        void Delete(Guid id);

        UserDto Update(UserEntity entity);

        UserDto InsertOrUpdate(UserEntity entity);

        //List<UserDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order);

    }
}
