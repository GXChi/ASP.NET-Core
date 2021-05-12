using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Domain.IRepositories;
using CloudNote.Service.DatumApp.Dtos;

namespace CloudNote.Service.DatumApp
{
    public class DatumAppService : IDatumAppService
    {
        private readonly IDatumRepository _DatumRepository;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
        public DatumAppService(IDatumRepository DatumRepository)
        {
            _DatumRepository = DatumRepository;
        }

        public DatumDto Insert(DatumEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            var Datum = _DatumRepository.Insert(entity);
            return mapper.Map<DatumDto>(Datum);
        }
        public DatumDto Update(DatumEntity Datum)
        {
            Datum.UpdateDate = DateTime.Now;
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<DatumDto>(_DatumRepository.Update(Datum));
        }
        public List<DatumDto> GetAll()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<DatumDto>>(_DatumRepository.GetAll());
        }

        public DatumDto Get(Guid id)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<DatumDto>(_DatumRepository.GetById(id));
        }

        public List<DatumDto> GetAllList()
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<DatumDto>>(_DatumRepository.GetAllList(it => it.Id != Guid.Empty).OrderBy(it => it.CreateDate));
        }

        public List<DatumDto> GetAllList(Expression<Func<DatumEntity, bool>> where)
        {
            var mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<DatumDto>>(_DatumRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _DatumRepository.Delete(id);
        }             

        public DatumDto InsertOrUpdate(DatumEntity Datum)
        {
            var mapper = mapperConfig.CreateMapper();
            var data = Get(Datum.Id);
            if (data != null)
            {
                return Update(Datum);
            }
            else
            {
                return Insert(Datum);
            }
        }

        //public List<DatumDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<DatumEntity, bool>> where, Expression<Func<DatumEntity, object>> order)
        //{
        //    return Mapper.Map<List<DatumDto>>(_DatumRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
