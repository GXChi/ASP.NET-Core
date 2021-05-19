using AutoMapper;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.UserApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CloudNote.Service.UserApp
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
       
        public UserAppService(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
            _mapper = mapperConfig.CreateMapper();
        }

        public List<UserDto> GetAllList(int startPage, int pageSize,out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order)
        {
            return _mapper.Map<List<UserDto>>(_userRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        }

        public List<UserDto> GetAllList(Expression<Func<UserEntity, bool>> where)
        {
            return _mapper.Map<List<UserDto>>(_userRepository.GetAllList(where));
        }

        public UserDto GetUserById(Guid id)
        {
            return _mapper.Map<UserDto>(_userRepository.GetRolesByUserId(id));
        }

        public bool InsertOrUpdate(UserDto entity)
        {
            var user = _userRepository.InsertOrUpdate(_mapper.Map<UserEntity>(entity));
            return user == null ? false : true;
        }

        public void DeleteBatch(List<Guid> ids)
        {
            _userRepository.Delete(x=>ids.Contains(x.Id));
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public UserDto CheckUser(string userName, string passWord)
        {
            return _mapper.Map<UserDto>(_userRepository.CheckUser(userName, passWord));
        }

      
        //public List<UserDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order)
        //{
        //    return Mapper.Map<List<UserDto>>(_userRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
