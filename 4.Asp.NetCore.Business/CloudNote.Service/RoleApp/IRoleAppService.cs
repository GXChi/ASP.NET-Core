using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.RoleApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.RoleApp
{
    public interface IRoleAppService
    {
        List<RoleDto> GetAllList();

        List<RoleDto> GetAllList(Expression<Func<RoleEntity, bool>> where);

        RoleDto GetById(Guid id);

        void Delete(Guid id);

        bool InsertOrUpdate(RoleDto entity);

        List<RoleDto> GetPageList(int startPage, int pageSize, out int rowCount, Expression<Func<RoleEntity, bool>> where, Expression<Func<RoleEntity, object>> order);

    }
}
