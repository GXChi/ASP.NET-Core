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
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public PhotoAppService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
         
        public PhotoDto Insert(PhotoEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var photo = _photoRepository.Insert(entity);
            return mapper.Map<PhotoDto>(photo);
        }
        public PhotoDto Update(PhotoEntity photo)
        {
            photo.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<PhotoDto>(_photoRepository.Update(photo));
        }
        public List<PhotoDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<PhotoDto>>(_photoRepository.GetAll());
        }

        public PhotoDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<PhotoDto>(_photoRepository.GetById(id));
        }

        public List<PhotoDto> GetAllList()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<PhotoDto>>(_photoRepository.GetAllList(it => it.Id != Guid.Empty).OrderBy(it => it.CreateDate));
        }

        public List<PhotoDto> GetAllList(Expression<Func<PhotoEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<PhotoDto>>(_photoRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _photoRepository.Delete(id);
        }             

        public PhotoDto InsertOrUpdate(PhotoEntity photo)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(photo.Id);
            if (data != null)
            {
                return Update(photo);
            }
            else
            {
                return Insert(photo);
            }
        }

        //public List<PhotoDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<PhotoEntity, bool>> where, Expression<Func<PhotoEntity, object>> order)
        //{
        //    return Mapper.Map<List<PhotoDto>>(_photoRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
