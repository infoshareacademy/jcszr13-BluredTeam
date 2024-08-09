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

        public DbSet<Visit> Visits { get; set; }
        public DbSet<User> AppUsers { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=ASIK\SQLEXPRESS;Database=PP0EfCore;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//Identity base
			base.OnModelCreating(modelBuilder);


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
