using CloudNote.Domain.Entities;
using CloudNote.Service.NoteApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CloudNote.Service.NoteApp
{
    public interface INoteAppService
    {
        NoteDto Insert(NoteDto dto);

        List<NoteDto> GetAll();

        List<NoteDto> GetAllList(Expression<Func<NoteEntity, bool>> where);

        NoteDto Get(Guid id);

        void Delete(Guid id);

        NoteDto Update(NoteEntity article);

        //List<NoteDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<NoteEntity, bool>> where, Expression<Func<NoteEntity, object>> order);

    }
}
