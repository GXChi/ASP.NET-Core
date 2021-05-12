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
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public NoteAppService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
         
        public NoteDto Insert(NoteEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var note = _noteRepository.Insert(entity);
            return mapper.Map<NoteDto>(note);
        }
        public NoteDto Update(NoteEntity note)
        {
            note.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<NoteDto>(_noteRepository.Update(note));
        }
        public List<NoteDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<NoteDto>>(_noteRepository.GetAll());
        }

        public NoteDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<NoteDto>(_noteRepository.GetById(id));
        }

        public List<NoteDto> GetAllList()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<NoteDto>>(_noteRepository.GetAllList(it => it.Id != Guid.Empty).OrderBy(it => it.CreateDate));
        }

        public List<NoteDto> GetAllList(Expression<Func<NoteEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<NoteDto>>(_noteRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _noteRepository.Delete(id);
        }             

        public NoteDto InsertOrUpdate(NoteEntity note)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(note.Id);
            if (data != null)
            {
                return Update(note);
            }
            else
            {
                return Insert(note);
            }
        }

        //public List<NoteDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<NoteEntity, bool>> where, Expression<Func<NoteEntity, object>> order)
        //{
        //    return Mapper.Map<List<NoteDto>>(_noteRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
