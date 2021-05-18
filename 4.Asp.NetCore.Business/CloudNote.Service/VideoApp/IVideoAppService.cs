using CloudNote.Domain.Entities;
using CloudNote.Service.VideoApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.VideoApp
{
    public interface IVideoAppService
    {
        List<VideoDto> GetAllList();

        List<VideoDto> GetAllList(Expression<Func<VideoEntity, bool>> where);

        VideoDto GetById(Guid id);

        void Delete(Guid id);

        bool InsertOrUpdate(VideoDto entity);

        //List<VideoDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<VideoEntity, bool>> where, Expression<Func<VideoEntity, object>> order);

    }
}
