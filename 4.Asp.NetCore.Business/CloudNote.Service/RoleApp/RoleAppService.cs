using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AutoMapper;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.RoleApp;
using CloudNote.Service.RoleApp.Dtos;

namespace CloudNote.Service.NoteApp
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleRepository _roleRepository;   
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public RoleAppService(IRoleRepository RoleRepository)
        {
            _roleRepository = RoleRepository;
            _mapper = mapperConfig.CreateMapper();
        }
           
        public RoleDto GetById(Guid id)
        {        
            return _mapper.Map<RoleDto>(_roleRepository.GetById(id));
        }

        public List<RoleDto> GetAllList()
        {
            return _mapper.Map<List<RoleDto>>(_roleRepository.GetAllList());
        }

        public List<RoleDto> GetAllList(Expression<Func<RoleEntity, bool>> where)
        {         
            return _mapper.Map<List<RoleDto>>(_roleRepository.GetAllList(where));
        }

        public void Delete(Guid id)
        {
            _roleRepository.Delete(id);
        }             

        public bool InsertOrUpdate(RoleDto dto)
        {
            var result = _roleRepository.InsertOrUpdate(_mapper.Map<RoleEntity>(dto));
            return result == null ? false : true;
        }

        public List<RoleDto> GetPageList(int startPage, int pageSize, out int rowCount, Expression<Func<RoleEntity, bool>> where, Expression<Func<RoleEntity, object>> order)
        {
            return _mapper.Map<List<RoleDto>>(_roleRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        }
    }
}
