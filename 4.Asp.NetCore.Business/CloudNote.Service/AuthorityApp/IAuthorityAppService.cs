using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.AuthorityApp.Dtos;

namespace CloudNote.Service.NoteApp
{
    public interface IAuthorityAppService
    {
        List<AuthorityDto> GetAllList();

        List<AuthorityDto> GetAllList(Expression<Func<AuthorityEntity, bool>> where);

        AuthorityDto GetList(Guid id);

        void Delete(Guid id);

        bool InsertOrUpdate(AuthorityDto entity);

        //List<AuthorityDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<AuthorityEntity, bool>> where, Expression<Func<AuthorityEntity, object>> order);

    }
}
