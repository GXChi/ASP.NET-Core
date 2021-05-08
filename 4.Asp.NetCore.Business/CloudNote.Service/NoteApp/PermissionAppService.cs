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
    public class PermissionAppService : IPermissionAppService
    {
        private readonly IPermissionRepository _PermissionRepository;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public PermissionAppService(IPermissionRepository PermissionRepository)
        {
            _PermissionRepository = PermissionRepository;
        }

        public PermissionDto Insert(PermissionEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var Permission = _PermissionRepository.Insert(entity);
            return mapper.Map<PermissionDto>(Permission);
        }
        public PermissionDto Update(PermissionEntity Permission)
        {
            Permission.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<PermissionDto>(_PermissionRepository.Update(Permission));
        }
        public List<PermissionDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<PermissionDto>>(_PermissionRepository.GetAll());
        }

        public PermissionDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<PermissionDto>(_PermissionRepository.GetById(id));
        }

        //public List<PermissionDto> GetAllList()
        //{
        //    return Mapper.Map<List<PermissionDto>>(_PermissionRepository.GetAllList(it=>it.Id!=Guid.Empty).OrderBy(it => it.Content));
        //}

        public List<PermissionDto> GetAllList(Expression<Func<PermissionEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<PermissionDto>>(_PermissionRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _PermissionRepository.Delete(id);
        }             

        public PermissionDto InsertOrUpdate(PermissionEntity Permission)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(Permission.Id);
            if (data != null)
            {
                return Update(Permission);
            }
            else
            {
                return Insert(Permission);
            }
        }

        //public List<PermissionDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<PermissionEntity, bool>> where, Expression<Func<PermissionEntity, object>> order)
        //{
        //    return Mapper.Map<List<PermissionDto>>(_PermissionRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
