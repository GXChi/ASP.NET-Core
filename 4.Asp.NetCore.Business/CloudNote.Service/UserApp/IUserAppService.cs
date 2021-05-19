﻿using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.UserApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.UserApp
{
    public interface IUserAppService
    {
        UserDto CheckUser(string userName, string passWord);

        public List<UserDto> GetAllList(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order);

        List<UserDto> GetAllList(Expression<Func<UserEntity, bool>> where);

        UserDto GetUserById(Guid id);

        bool InsertOrUpdate(UserDto entity);

        void Delete(Guid id);

        void DeleteBatch(List<Guid> ids);

        //List<UserDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order);

    }
}
