using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.NoteApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CloudNote.Service.NoteApp
{
    public interface IPermissionAppService
    {
        PermissionDto Insert(PermissionEntity dto);

        List<PermissionDto> GetAll();

        List<PermissionDto> GetAllList(Expression<Func<PermissionEntity, bool>> where);

        PermissionDto Get(Guid id);

        void Delete(Guid id);

        PermissionDto Update(PermissionEntity entity);

        PermissionDto InsertOrUpdate(PermissionEntity entity);

        //List<PermissionDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<PermissionEntity, bool>> where, Expression<Func<PermissionEntity, object>> order);

    }
}
