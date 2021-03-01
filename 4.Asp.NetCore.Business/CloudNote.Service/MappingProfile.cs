using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Service.NoteApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NoteEntity, NoteDto>();
        }
    }
}
