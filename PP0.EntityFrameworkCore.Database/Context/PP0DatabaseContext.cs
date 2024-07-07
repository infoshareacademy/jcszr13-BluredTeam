﻿using Microsoft.EntityFrameworkCore;
using PP0.EntityFrameworkCore.Database.Entities;
using PP0.EntityFrameworkCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.EntityFrameworkCore.Database.Context
{
    internal class PP0DatabaseContext : DbContext
    {
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<User> Users{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PP0EfCore;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Users
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Login).HasMaxLength(400);
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(400);

            //UsersRoles
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UsersRoles");
                entity.HasKey(x => x.UserRoleID);
                entity.Property(x => x.RoleType).HasConversion(x => x.ToString(), x => (RoleType)Enum.Parse(typeof(RoleType), x));
                entity.Property(x => x.UserRoleID).IsRequired();
                entity.Property(x => x.RoleType).HasMaxLength(20);


            });
            }
    }
}