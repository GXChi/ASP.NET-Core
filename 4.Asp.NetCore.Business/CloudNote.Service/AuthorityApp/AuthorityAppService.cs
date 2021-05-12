using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.NoteApp;
using CloudNote.Service.AuthorityApp.Dtos;

namespace CloudNote.Service.AuthorityApp
{
    public class AuthorityAppService : IAuthorityAppService
    {
        private readonly IAuthorityRepository _AuthorityRepository;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public AuthorityAppService(IAuthorityRepository AuthorityRepository)
        {
            _AuthorityRepository = AuthorityRepository;
        }

        public AuthorityDto Insert(AuthorityEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var Authority = _AuthorityRepository.Insert(entity);
            return mapper.Map<AuthorityDto>(Authority);
        }
        public AuthorityDto Update(AuthorityEntity Authority)
        {
            Authority.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<AuthorityDto>(_AuthorityRepository.Update(Authority));
        }
        public List<AuthorityDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<AuthorityDto>>(_AuthorityRepository.GetAll());
        }

        public AuthorityDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<AuthorityDto>(_AuthorityRepository.GetById(id));
        }

        //public List<AuthorityDto> GetAllList()
        //{
        //    return Mapper.Map<List<AuthorityDto>>(_AuthorityRepository.GetAllList(it=>it.Id!=Guid.Empty).OrderBy(it => it.Content));
        //}

        public List<AuthorityDto> GetAllList(Expression<Func<AuthorityEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<AuthorityDto>>(_AuthorityRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _AuthorityRepository.Delete(id);
        }             

        public AuthorityDto InsertOrUpdate(AuthorityEntity Authority)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(Authority.Id);
            if (data != null)
            {
                return Update(Authority);
            }
            else
            {
                return Insert(Authority);
            }
        }

        //public List<AuthorityDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<AuthorityEntity, bool>> where, Expression<Func<AuthorityEntity, object>> order)
        //{
        //    return Mapper.Map<List<AuthorityDto>>(_AuthorityRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
