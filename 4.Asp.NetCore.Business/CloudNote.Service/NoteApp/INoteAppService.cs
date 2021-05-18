using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CloudNote.Domain.Entities;
using CloudNote.Service.NoteApp.Dtos;

namespace CloudNote.Service.NoteApp
{
    public interface INoteAppService
    {
        List<NoteDto> GetAllList();

        List<NoteDto> GetAllList(Expression<Func<NoteEntity, bool>> where);

        NoteDto GetById(Guid id);

        void Delete(Guid id);
    
        bool InsertOrUpdate(NoteDto entity);

        //List<NoteDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<NoteEntity, bool>> where, Expression<Func<NoteEntity, object>> order);

    }
}
