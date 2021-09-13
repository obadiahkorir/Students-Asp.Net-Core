using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Students.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentsModel> Students { get; set; }

        public DbSet<County> County { get; set; }

        public DbSet<Course> Course { get; set; }
    }
}
