using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
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
            CreateMap<UserEntity, UserDto>();
            CreateMap<RoleEntity, RoleDto>();
            CreateMap<PermissionEntity, PermissionDto>();
        }
    }
}
