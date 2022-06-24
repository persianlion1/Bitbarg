using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitbargBackendTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitbargBackendTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
