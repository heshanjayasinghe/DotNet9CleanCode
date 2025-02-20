using DotNet9.Domain.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Insfrastructure
{
    public class DotNet9DbContext : DbContext
    {
        public DotNet9DbContext() { }

        public DotNet9DbContext(DbContextOptions<DotNet9DbContext> options):base(options) {
          
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Song> Songs { get; set; }


    }
}
