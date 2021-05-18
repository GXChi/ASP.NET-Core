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
        private readonly IFolderRepository _folderRepository;
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
       
        public FolderAppService(IFolderRepository FolderRepository)
        {
            _folderRepository = FolderRepository;
            _mapper = mapperConfig.CreateMapper();
        }

        public FolderDto GetById(Guid id)
        {          
            return _mapper.Map<FolderDto>(_folderRepository.GetById(id));
        }

        public List<FolderDto> GetAllList()
        {
            return _mapper.Map<List<FolderDto>>(_folderRepository.GetAllList());
        }

        public List<FolderDto> GetAllList(Expression<Func<FolderEntity, bool>> where)
        {
            return _mapper.Map<List<FolderDto>>(_folderRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _folderRepository.Delete(id);
        }             

        public bool InsertOrUpdate(FolderDto dto)
        {
            var result = _folderRepository.InsertOrUpdate(_mapper.Map<FolderEntity>(dto));
            return result == null ? false : true;
        }

        //public List<FolderDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<FolderEntity, bool>> where, Expression<Func<FolderEntity, object>> order)
        //{
        //    return Mapper.Map<List<FolderDto>>(_FolderRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
