using Microsoft.EntityFrameworkCore;
using RPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        // для миграции 
        public DbSet<Character> Characters { get; set; }
    }
}
