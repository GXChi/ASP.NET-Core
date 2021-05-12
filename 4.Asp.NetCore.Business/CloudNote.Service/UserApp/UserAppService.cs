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
        private readonly IUserRepository _UserRepository;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public UserAppService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public UserDto Insert(UserEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var User = _UserRepository.Insert(entity);
            return mapper.Map<UserDto>(User);
        }
        public UserDto Update(UserEntity User)
        {
            User.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<UserDto>(_UserRepository.Update(User));
        }
        public List<UserDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<UserDto>>(_UserRepository.GetAll());
        }

        public UserDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<UserDto>(_UserRepository.GetById(id));
        }

        //public List<UserDto> GetAllList()
        //{
        //    return Mapper.Map<List<UserDto>>(_UserRepository.GetAllList(it=>it.Id!=Guid.Empty).OrderBy(it => it.Content));
        //}

        public List<UserDto> GetAllList(Expression<Func<UserEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<UserDto>>(_UserRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _UserRepository.Delete(id);
        }             

        public UserDto InsertOrUpdate(UserEntity User)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(User.Id);
            if (data != null)
            {
                return Update(User);
            }
            else
            {
                return Insert(User);
            }
        }

        //public List<UserDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<UserEntity, bool>> where, Expression<Func<UserEntity, object>> order)
        //{
        //    return Mapper.Map<List<UserDto>>(_UserRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
