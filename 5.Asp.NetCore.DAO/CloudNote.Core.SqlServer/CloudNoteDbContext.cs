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

        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<FolderEntity> Folders{ get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<VideoEntity> Videos { get; set; }
        public DbSet<DatumEntity> Datums { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<AuthorityEntity> Authoritys { get; set; }
        public DbSet<RoleAuthorityEntity> RoleAuthoritys { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }

    }
}
