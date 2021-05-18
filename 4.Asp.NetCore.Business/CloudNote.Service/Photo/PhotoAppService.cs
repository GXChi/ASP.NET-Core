using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.PhotoApp.Dtos;

namespace CloudNote.Service.PhotoApp
{
    public class PhotoAppService : IPhotoAppService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
       
        public PhotoAppService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
            _mapper = mapperConfig.CreateMapper();
        }
       
        public List<PhotoDto> GetAllList()
        {           
            return _mapper.Map<List<PhotoDto>>(_photoRepository.GetAllList());
        }

        public PhotoDto GetById(Guid id)
        {        
            return _mapper.Map<PhotoDto>(_photoRepository.GetById(id));
        }
      
        public List<PhotoDto> GetAllList(Expression<Func<PhotoEntity, bool>> where)
        {            
            return _mapper.Map<List<PhotoDto>>(_photoRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _photoRepository.Delete(id);
        }             

        public bool InsertOrUpdate(PhotoDto photo)
        {
            var result = _photoRepository.InsertOrUpdate(_mapper.Map<PhotoEntity>(photo));
            return result == null ? false : true;
        }

        //public List<PhotoDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<PhotoEntity, bool>> where, Expression<Func<PhotoEntity, object>> order)
        //{
        //    return Mapper.Map<List<PhotoDto>>(_photoRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
