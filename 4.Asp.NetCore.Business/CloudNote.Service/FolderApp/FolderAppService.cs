using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.FolderApp.Dtos;

namespace CloudNote.Service.FolderApp
{
    public class FolderAppService : IFolderAppService
    {
        private readonly IFolderRepository _FolderRepository;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public FolderAppService(IFolderRepository FolderRepository)
        {
            _FolderRepository = FolderRepository;
        }

        public FolderDto Insert(FolderEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var Folder = _FolderRepository.Insert(entity);
            return mapper.Map<FolderDto>(Folder);
        }
        public FolderDto Update(FolderEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<FolderDto>(_FolderRepository.Update(entity));
        }
        public List<FolderDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<FolderDto>>(_FolderRepository.GetAll());
        }

        public FolderDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<FolderDto>(_FolderRepository.GetById(id));
        }

        public List<FolderDto> GetAllList()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<FolderDto>>(_FolderRepository.GetAllList(it => it.Id != Guid.Empty).OrderBy(it => it.CreateDate));
        }

        public List<FolderDto> GetAllList(Expression<Func<FolderEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<FolderDto>>(_FolderRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _FolderRepository.Delete(id);
        }             

        public FolderDto InsertOrUpdate(FolderEntity Folder)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(Folder.Id);
            if (data != null)
            {
                return Update(Folder);
            }
            else
            {
                return Insert(Folder);
            }
        }

        //public List<FolderDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<FolderEntity, bool>> where, Expression<Func<FolderEntity, object>> order)
        //{
        //    return Mapper.Map<List<FolderDto>>(_FolderRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
