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
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public VideoAppService(IVideoRepository VideoRepository)
        {
            _videoRepository = VideoRepository;
            _mapper = mapperConfig.CreateMapper();
        }
     
        public List<VideoDto> GetAllList()
        {
            return _mapper.Map<List<VideoDto>>(_videoRepository.GetAllList());
        }

        public VideoDto GetById(Guid id)
        {
            return _mapper.Map<VideoDto>(_videoRepository.GetById(id));
        }
       
        public List<VideoDto> GetAllList(Expression<Func<VideoEntity, bool>> where)
        {
            return _mapper.Map<List<VideoDto>>(_videoRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _videoRepository.Delete(id);
        }             

        public bool InsertOrUpdate(VideoDto dto)
        {
            var result = _videoRepository.InsertOrUpdate(_mapper.Map<VideoEntity>(dto));
            return result == null ? false : true;
        }

        //public List<VideoDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<VideoEntity, bool>> where, Expression<Func<VideoEntity, object>> order)
        //{
        //    return Mapper.Map<List<VideoDto>>(_VideoRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
