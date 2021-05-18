using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.NoteApp;
using CloudNote.Service.AuthorityApp.Dtos;
using System.Linq;

namespace CloudNote.Service.AuthorityApp
{
    public class AuthorityAppService : IAuthorityAppService
    {
        private readonly IAuthorityRepository _authorityRepository;
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
     
        public AuthorityAppService(IAuthorityRepository AuthorityRepository)
        {
            _authorityRepository = AuthorityRepository;
            _mapper = mapperConfig.CreateMapper();
        }

        public AuthorityDto GetList(Guid id)
        {
            return _mapper.Map<AuthorityDto>(_authorityRepository.GetById(id));
        }

        public List<AuthorityDto> GetAllList()
        {
            return _mapper.Map<List<AuthorityDto>>(_authorityRepository.GetAllList());
        }

        public List<AuthorityDto> GetAllList(Expression<Func<AuthorityEntity, bool>> where)
        {          
            return _mapper.Map<List<AuthorityDto>>(_authorityRepository.GetAllList(where));
        }

        public void Delete(Guid id)
        {
            _authorityRepository.Delete(id);
        }

        public bool InsertOrUpdate(AuthorityDto dto)
        {
            var result = _authorityRepository.InsertOrUpdate(_mapper.Map<AuthorityEntity>(dto));
            return result == null ? false : true;
        }


        //public List<AuthorityDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<AuthorityEntity, bool>> where, Expression<Func<AuthorityEntity, object>> order)
        //{
        //    return Mapper.Map<List<AuthorityDto>>(_AuthorityRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
