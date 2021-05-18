using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CloudNote.Domain.Entities;
using CloudNote.Service.PhotoApp.Dtos;

namespace CloudNote.Service.PhotoApp
{
    public interface IPhotoAppService
    {      
        List<PhotoDto> GetAllList();

        List<PhotoDto> GetAllList(Expression<Func<PhotoEntity, bool>> where);

        PhotoDto GetById(Guid id);

        void Delete(Guid id); 
     
        bool InsertOrUpdate(PhotoDto entity);

        //List<NoteDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<PhotoEntity, bool>> where, Expression<Func<PhotoEntity, object>> order);

    }
}
