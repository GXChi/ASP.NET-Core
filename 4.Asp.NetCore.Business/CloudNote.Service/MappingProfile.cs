using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.AuthorityApp.Dtos;
using CloudNote.Service.DatumApp.Dtos;
using CloudNote.Service.NoteApp.Dtos;
using CloudNote.Service.PhotoApp.Dtos;
using CloudNote.Service.RoleApp.Dtos;
using CloudNote.Service.UserApp.Dtos;
using CloudNote.Service.VideoApp.Dtos;
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
            CreateMap<VideoEntity, VideoDto>();
            CreateMap<PhotoEntity, PhotoDto>();
            CreateMap<DatumEntity, DatumDto>(); 
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserDto, UserEntity > ();
            CreateMap<UserRoleEntity, UserRoleDto>();
            CreateMap<RoleEntity, RoleDto>();
            CreateMap<RoleDto, RoleEntity>();
            CreateMap<RoleAuthorityEntity, RoleAuthorityDto>();
            CreateMap<AuthorityEntity, AuthorityDto>();
            CreateMap<AuthorityDto, AuthorityEntity>();
        }
    }
}
