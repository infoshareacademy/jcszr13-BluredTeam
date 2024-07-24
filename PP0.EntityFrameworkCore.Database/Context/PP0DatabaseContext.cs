using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PP0.EntityFrameworkCore.Database.Entities;
using PP0.EntityFrameworkCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.EntityFrameworkCore.Database.Context
{
    public class PP0DatabaseContext : IdentityDbContext<IdentityUser>
    {
		public PP0DatabaseContext(DbContextOptions<PP0DatabaseContext> options) : base(options)
		{

		}
		public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=ASIK\SQLEXPRESS;Database=PP0EfCore;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//Identity base
			base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("Visits");
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Doctor)
                .WithMany(x => x.DoctorVisits)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.Patient)
                .WithMany(x => x.PatientVisits)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
