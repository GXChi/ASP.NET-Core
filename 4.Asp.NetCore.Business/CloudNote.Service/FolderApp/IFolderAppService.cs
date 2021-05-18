using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CloudNote.Domain.Entities;
using CloudNote.Service.FolderApp.Dtos;

namespace CloudNote.Service.FolderApp
{
    public interface IFolderAppService
    {
        List<FolderDto> GetAllList();

        List<FolderDto> GetAllList(Expression<Func<FolderEntity, bool>> where);

        FolderDto GetById(Guid id);

        void Delete(Guid id);     

        bool InsertOrUpdate(FolderDto entity);

        //List<FolderDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<FolderEntity, bool>> where, Expression<Func<FolderEntity, object>> order);

    }
}
