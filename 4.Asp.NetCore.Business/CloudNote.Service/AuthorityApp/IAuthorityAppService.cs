using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.AuthorityApp.Dtos;

namespace CloudNote.Service.NoteApp
{
    public interface IAuthorityAppService
    {
        AuthorityDto Insert(AuthorityEntity dto);

        List<AuthorityDto> GetAll();

        List<AuthorityDto> GetAllList(Expression<Func<AuthorityEntity, bool>> where);

        AuthorityDto Get(Guid id);

        void Delete(Guid id);

        AuthorityDto Update(AuthorityEntity entity);

        AuthorityDto InsertOrUpdate(AuthorityEntity entity);

        //List<AuthorityDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<AuthorityEntity, bool>> where, Expression<Func<AuthorityEntity, object>> order);

    }
}
