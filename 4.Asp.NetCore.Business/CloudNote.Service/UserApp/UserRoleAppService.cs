using AutoMapper;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.UserApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CloudNote.Service.UserApp
{
    public class UserRoleAppService : IUserRoleAppService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
       
        public UserRoleAppService(IUserRoleRepository UserRoleRepository)
        {
            _userRoleRepository = UserRoleRepository;
            _mapper = mapperConfig.CreateMapper();
        }

        public UserDto GetUserById(Guid id)
        {
            return _mapper.Map<UserDto>(_userRoleRepository.GetById(id));
        }

        public bool InsertOrUpdate(UserRoleDto entity)
        {
            var user = _userRoleRepository.InsertOrUpdate(_mapper.Map<UserRoleEntity>(entity));
            return user == null ? false : true;
        }

        public void DeleteBatch(List<Guid> ids)
        {
            _userRoleRepository.Delete(x=>ids.Contains(x.Id));
        }

        public void Delete(Guid id)
        {
            _userRoleRepository.Delete(id);
        }

        public List<UserRoleDto> GetAllList(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order)
        {
            throw new NotImplementedException();
        }

        public List<UserRoleDto> GetAllList(Expression<Func<UserEntity, bool>> where)
        {
            return _mapper.Map<List<UserRoleDto>>(_userRoleRepository.GetAllList().ToList()); 
        }

        UserRoleDto IUserRoleAppService.GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }


        //public List<UserDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<UserRoleEntity, bool>> where, Expression<Func<UserRoleEntity, object>> order)
        //{
        //    return Mapper.Map<List<UserDto>>(_userRoleRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
