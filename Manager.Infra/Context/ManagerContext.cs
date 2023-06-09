﻿using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infra.Context
{
    public class ManagerContext : DbContext
    {
        //EF 
       public ManagerContext() { }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }
            
        public DbSet<User> Users { get; set; }



       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql
            ("Server=localhost;Port=5432;Database=postgres;User ID=postgres;Password=postgres;");
        }*/


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
           base.OnModelCreating(modelBuilder);
        }

    }
}
