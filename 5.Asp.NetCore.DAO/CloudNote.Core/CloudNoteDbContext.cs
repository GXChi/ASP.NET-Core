﻿using CloudNote.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CloudNote.Core
{
    public class CloudNoteDbContext : DbContext
    {
        public CloudNoteDbContext(DbContextOptions<CloudNoteDbContext> options)
            : base(options)
        { 
        
        }

        public DbSet<FolderEntity> Folder{ get; set; }
        public DbSet<NoteEntity> Note { get; set; }

    }
}
