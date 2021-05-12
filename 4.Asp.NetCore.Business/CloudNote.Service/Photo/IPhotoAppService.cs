using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CloudNote.Domain.Entities;
using CloudNote.Service.PhotoApp.Dtos;

namespace CloudNote.Service.PhotoApp
{
    public interface IPhotoAppService
    {
        PhotoDto Insert(PhotoEntity dto);

        List<PhotoDto> GetAll();

        List<PhotoDto> GetAllList(Expression<Func<PhotoEntity, bool>> where);

        PhotoDto Get(Guid id);

        void Delete(Guid id);

        PhotoDto Update(PhotoEntity entity);

        PhotoDto InsertOrUpdate(PhotoEntity entity);

        //List<NoteDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<PhotoEntity, bool>> where, Expression<Func<PhotoEntity, object>> order);

    }
}
