using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNote.Core.SqlServer
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CloudNoteDbContext>
    {
        public CloudNoteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CloudNoteDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CloudNoteDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new CloudNoteDbContext(optionsBuilder.Options);
        }
    }
}
