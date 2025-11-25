using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library_Management_System.Models;

namespace Library_Management_System.Data
{
    public class Library_Management_SystemContext : DbContext
    {
        public Library_Management_SystemContext (DbContextOptions<Library_Management_SystemContext> options)
            : base(options)
        {
        }

        public DbSet<Library_Management_System.Models.LibrarySystem> LibrarySystem { get; set; } = default!;
    }
}
