using BarberApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BarberApi.Data
{
    public class BarberContext : DbContext
    {
        public BarberContext(DbContextOptions<BarberContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Appointment>()
                .HasMany(p => p.Services)
                .WithOne()
                .IsRequired()
                .HasForeignKey("AppointmentId"); //Shadow property
            builder.Entity<Appointment>().Property(r => r.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Appointment>().Property(r => r.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Appointment>().Property(r => r.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Entity<Appointment>().Property(r => r.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Appointment>().Property(r => r.Remarks).HasMaxLength(200);
            builder.Entity<Appointment>().Property(r => r.Date).IsRequired();

            builder.Entity<StandardService>().Property(r => r.Name).IsRequired().HasMaxLength(50);
            builder.Entity<StandardService>().Property(r => r.Price).IsRequired();

            builder.Entity<StandardService>().HasData(
                new StandardService
                {
                    Id = 1,
                    Name = "trim cut",
                    Price = (double?)30
                },
                new StandardService
                {
                    Id = 2,
                    Name = "quick shave",
                    Price = (double?)20
                },
                new StandardService
                {
                    Id = 3,
                    Name = "cut and brushing",
                    Price = (double?)60
                },
                new StandardService
                {
                    Id = 4,
                    Name = "coloring",
                    Price = (double?)70
                });

            //Another way to seed the database
            builder.Entity<Appointment>().HasData(
                 new Appointment
                 {
                     Id = 1,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, 08, 10, 15, 0),
                 },
                 new Appointment
                 {
                     Id = 2,
                     FirstName = "Mia",
                     LastName = "De Smedt",
                     PhoneNumber = "0488888888",
                     Email = "miadesmedt@email.com",
                     Remarks = "This is also a remark.",
                     Date = new DateTime(2021, 07, 08, 9, 15, 0),
                 });
            builder.Entity<Service>().HasData(
                   //Shadow property can be used for the foreign key, in combination with anonymous objects
                   new { Id = 1, Name = "trim cut", Price = (double?)30, AppointmentId = 1 },
                   new { Id = 2, Name = "quick shave", Price = (double?)20, AppointmentId = 1 },
                   new { Id = 3, Name = "cut and brushing", Price = (double?)60, AppointmentId = 2 },
                   new { Id = 4, Name = "coloring", Price = (double?)70, AppointmentId = 2 }
                );
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<StandardService> StandardServices { get; set; }
    }
}