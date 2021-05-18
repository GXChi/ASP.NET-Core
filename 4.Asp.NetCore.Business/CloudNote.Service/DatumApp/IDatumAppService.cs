using CloudNote.Domain.Entities;
using CloudNote.Service.DatumApp.Dtos;
using CloudNote.Service.NoteApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CloudNote.Service.DatumApp
{
    public interface IDatumAppService
    {

        List<DatumDto> GetAllList();

        List<DatumDto> GetAllList(Expression<Func<DatumEntity, bool>> where);

        DatumDto GetDatumById(Guid id);

        void Delete(Guid id);

        bool InsertOrUpdate(DatumDto dto);

        //List<DatumDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<DatumEntity, bool>> where, Expression<Func<DatumEntity, object>> order);

    }
}
