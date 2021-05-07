using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
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
        public DbSet<UserEntity> User { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<PermissionEntity> Permission { get; set; }

    }
}
