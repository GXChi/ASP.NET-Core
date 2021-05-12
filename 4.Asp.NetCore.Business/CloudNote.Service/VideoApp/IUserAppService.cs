using CloudNote.Domain.Entities;
using CloudNote.Service.VideoApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.VideoApp
{
    public interface IVideoAppService
    {
        VideoDto Insert(VideoEntity dto);

        List<VideoDto> GetAll();

        List<VideoDto> GetAllList(Expression<Func<VideoEntity, bool>> where);

        VideoDto Get(Guid id);

        void Delete(Guid id);

        VideoDto Update(VideoEntity entity);

        VideoDto InsertOrUpdate(VideoEntity entity);

        //List<VideoDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<VideoEntity, bool>> where, Expression<Func<VideoEntity, object>> order);

    }
}
