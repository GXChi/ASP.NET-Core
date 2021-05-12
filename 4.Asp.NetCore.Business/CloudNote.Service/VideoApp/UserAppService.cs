using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.VideoApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.VideoApp
{
    public class VideoAppService : IVideoAppService
    {
        private readonly IVideoRepository _VideoRepository;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public VideoAppService(IVideoRepository VideoRepository)
        {
            _VideoRepository = VideoRepository;
        }

        public VideoDto Insert(VideoEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var Video = _VideoRepository.Insert(entity);
            return mapper.Map<VideoDto>(Video);
        }
        public VideoDto Update(VideoEntity Video)
        {
            Video.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<VideoDto>(_VideoRepository.Update(Video));
        }
        public List<VideoDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<VideoDto>>(_VideoRepository.GetAll());
        }

        public VideoDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<VideoDto>(_VideoRepository.GetById(id));
        }

        //public List<VideoDto> GetAllList()
        //{
        //    return Mapper.Map<List<VideoDto>>(_VideoRepository.GetAllList(it=>it.Id!=Guid.Empty).OrderBy(it => it.Content));
        //}

        public List<VideoDto> GetAllList(Expression<Func<VideoEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<VideoDto>>(_VideoRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _VideoRepository.Delete(id);
        }             

        public VideoDto InsertOrUpdate(VideoEntity Video)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(Video.Id);
            if (data != null)
            {
                return Update(Video);
            }
            else
            {
                return Insert(Video);
            }
        }

        //public List<VideoDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<VideoEntity, bool>> where, Expression<Func<VideoEntity, object>> order)
        //{
        //    return Mapper.Map<List<VideoDto>>(_VideoRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
