using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CloudNote.Domain.Entities;
using CloudNote.Service.FolderApp.Dtos;

namespace CloudNote.Service.FolderApp
{
    public interface IFolderAppService
    {
        FolderDto Insert(FolderEntity dto);

        List<FolderDto> GetAll();

        List<FolderDto> GetAllList(Expression<Func<FolderEntity, bool>> where);

        FolderDto Get(Guid id);

        void Delete(Guid id);

        FolderDto Update(FolderEntity entity);

        FolderDto InsertOrUpdate(FolderEntity entity);

        //List<FolderDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<FolderEntity, bool>> where, Expression<Func<FolderEntity, object>> order);

    }
}
