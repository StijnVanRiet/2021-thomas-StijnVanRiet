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
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 8, 0, 0),
                 },
                 new Appointment
                 {
                     Id = 2,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 8, 45, 0),
                 },
                 new Appointment
                 {
                     Id = 3,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 9, 30, 0),
                 },
                 new Appointment
                 {
                     Id = 4,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 10, 15, 0),
                 },
                 new Appointment
                 {
                     Id = 5,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 11, 0, 0),
                 },
                 new Appointment
                 {
                     Id = 6,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 11, 45, 0),
                 },
                 new Appointment
                 {
                     Id = 7,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 13, 0, 0),
                 },
                 new Appointment
                 {
                     Id = 8,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 13, 45, 0),
                 },
                 new Appointment
                 {
                     Id = 9,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 14, 30, 0),
                 },
                 new Appointment
                 {
                     Id = 10,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 15, 15, 0),
                 },
                 new Appointment
                 {
                     Id = 11,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 16, 0, 0),
                 },
                 new Appointment
                 {
                     Id = 12,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 16, 45, 0),
                 },
                  new Appointment
                  {
                      Id = 13,
                      FirstName = "Stijn",
                      LastName = "Van Riet",
                      PhoneNumber = "0496512796",
                      Email = "stijn.vanriet@student.hogent.be",
                      Remarks = "This is a remark.",
                      Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 17, 30, 0),
                  },
                 new Appointment
                 {
                     Id = 14,
                     FirstName = "Mia",
                     LastName = "De Smedt",
                     PhoneNumber = "0488888888",
                     Email = "miadesmedt@email.com",
                     Remarks = "This is also a remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 3, 8, 45, 0),
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