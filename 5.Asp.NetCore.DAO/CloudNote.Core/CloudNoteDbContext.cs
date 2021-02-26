using CloudNote.Enity;
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

        public DbSet<Folder> Folder { get; set; }

    }
}
