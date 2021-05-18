using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.NoteApp.Dtos;

namespace CloudNote.Service.NoteApp
{
    public class NoteAppService : INoteAppService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
     
        public NoteAppService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
            _mapper = mapperConfig.CreateMapper();
        }

        public NoteDto GetById(Guid id)
        {          
            return _mapper.Map<NoteDto>(_noteRepository.GetById(id));
        }

        public List<NoteDto> GetAllList()
        {
            return _mapper.Map<List<NoteDto>>(_noteRepository.GetAllList());
        }

        public List<NoteDto> GetAllList(Expression<Func<NoteEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return _mapper.Map<List<NoteDto>>(_noteRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _noteRepository.Delete(id);
        }             

        public bool InsertOrUpdate(NoteDto dto)
        {
            var result = _noteRepository.InsertOrUpdate(_mapper.Map<NoteEntity>(dto));
            return result == null ? false : true;
        }

        //public List<NoteDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<NoteEntity, bool>> where, Expression<Func<NoteEntity, object>> order)
        //{
        //    return Mapper.Map<List<NoteDto>>(_noteRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
