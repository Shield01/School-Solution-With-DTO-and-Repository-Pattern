using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.Models;

namespace UseDTOAndRepositoryPattern.Data_Access_Layer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
