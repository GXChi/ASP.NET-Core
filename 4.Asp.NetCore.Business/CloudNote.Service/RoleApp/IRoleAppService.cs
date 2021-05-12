using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.RoleApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.RoleApp
{
    public interface IRoleAppService
    {
        RoleDto Insert(RoleEntity dto);

        List<RoleDto> GetAll();

        List<RoleDto> GetAllList(Expression<Func<RoleEntity, bool>> where);

        RoleDto Get(Guid id);

        void Delete(Guid id);

        RoleDto Update(RoleEntity entity);

        RoleDto InsertOrUpdate(RoleEntity entity);

        //List<RoleDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<RoleEntity, bool>> where, Expression<Func<RoleEntity, object>> order);

    }
}
