using AutoMapper;
using CloudNote.Domain.Entities;
using CloudNote.Service.NoteApp.Dtos;
using System;

namespace CloudNote.Service
{
    public class MyMapper
    {
        public static MapperConfiguration Initialize()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            return config;
        }
    }
}
