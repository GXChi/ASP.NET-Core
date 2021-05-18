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
        private readonly IDatumRepository _datumRepository;
        private readonly IMapper _mapper;
        MapperConfiguration mapperConfig = MyMapper.Initialize();
       
        public DatumAppService(IDatumRepository DatumRepository)
        {
            _datumRepository = DatumRepository;
            _mapper = mapperConfig.CreateMapper();
        }

        public List<DatumDto> GetAllList()
        {
            return _mapper.Map<List<DatumDto>>(_datumRepository.GetAllList());
        }

        public DatumDto GetDatumById(Guid id)
        {
            return _mapper.Map<DatumDto>(_datumRepository.GetById(id));
        }

        public List<DatumDto> GetAllList(Expression<Func<DatumEntity, bool>> where)
        {
            return _mapper.Map<List<DatumDto>>(_datumRepository.GetAllList(where));
        }
        public void Delete(Guid id)
        {
            _datumRepository.Delete(id);
        }

        public bool InsertOrUpdate(DatumDto dto)
        {
            var result = _datumRepository.InsertOrUpdate(_mapper.Map<DatumEntity>(dto));
            return result == null ? false : true;
        }

        //public List<DatumDto> GetPage(int startPage, int pageSize, out int rowCount, Expression<Func<DatumEntity, bool>> where, Expression<Func<DatumEntity, object>> order)
        //{
        //    return Mapper.Map<List<DatumDto>>(_DatumRepository.LoadPageList(startPage, pageSize, out rowCount, where, order));
        //}
    }
}
