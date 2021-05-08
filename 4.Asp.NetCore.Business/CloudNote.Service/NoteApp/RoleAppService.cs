using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.NoteApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CloudNote.Service.NoteApp
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleRepository _RoleRepository;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public RoleAppService(IRoleRepository RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        public RoleDto Insert(RoleEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var Role = _RoleRepository.Insert(entity);
            return mapper.Map<RoleDto>(Role);
        }
        public RoleDto Update(RoleEntity Role)
        {
            Role.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<RoleDto>(_RoleRepository.Update(Role));
        }
        public List<RoleDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<RoleDto>>(_RoleRepository.GetAll());
        }

        public RoleDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<RoleDto>(_RoleRepository.GetById(id));
        }

        //public List<RoleDto> GetAllList()
        //{
        //    return Mapper.Map<List<RoleDto>>(_RoleRepository.GetAllList(it=>it.Id!=Guid.Empty).OrderBy(it => it.Content));
        //}

        public List<RoleDto> GetAllList(Expression<Func<RoleEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<RoleDto>>(_RoleRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _RoleRepository.Delete(id);
        }             

        public RoleDto InsertOrUpdate(RoleEntity Role)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(Role.Id);
            if (data != null)
            {
                return Update(Role);
            }
            else
            {
                return Insert(Role);
            }
        }

        //public List<RoleDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<RoleEntity, bool>> where, Expression<Func<RoleEntity, object>> order)
        //{
        //    return Mapper.Map<List<RoleDto>>(_RoleRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
