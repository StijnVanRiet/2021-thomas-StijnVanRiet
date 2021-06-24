using Microsoft.EntityFrameworkCore;
using BarberApi.Models;
using System;
using System.Collections.Generic;

namespace BarberApi.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Reservation>()
                .HasMany(p => p.Services)
                .WithOne()
                .IsRequired()
                .HasForeignKey("ReservationId"); //Shadow property
            builder.Entity<Reservation>().Property(r => r.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Reservation>().Property(r => r.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Reservation>().Property(r => r.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Entity<Reservation>().Property(r => r.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Reservation>().Property(r => r.Remarks).HasMaxLength(50);
            builder.Entity<Reservation>().Property(r => r.Barber).HasMaxLength(50);
            builder.Entity<Reservation>().Property(r => r.Date).IsRequired();

            //Another way to seed the database
            builder.Entity<Reservation>().HasData(
                 new Reservation
                 {
                     Id = 1,
                     FirstName = "Stijn",
                     LastName = "Van Riet",
                     PhoneNumber = "0496512796",
                     Email = "stijn.vanriet@student.hogent.be",
                     Remarks = "This is a remark.",
                     Barber = "Piet",
                     Date = new DateTime(2021, 08, 08, 10, 15, 0),
                 },
                 new Reservation
                 {
                     Id = 2,
                     FirstName = "Mia",
                     LastName = "De Smed",
                     PhoneNumber = "0488888888",
                     Email = "miadesmedt@email.com",
                     Remarks = "This is also a remark.",
                     Barber = "Jef",
                     Date = new DateTime(2021, 07, 08, 9, 15, 0),
                 });
            builder.Entity<Service>().HasData(
                   //Shadow property can be used for the foreign key, in combination with anonymous objects
                   new { Id = 1, Name = "trim cut", Price = (double?)30, ReservationId = 1 },
                   new { Id = 2, Name = "quick shave", Price = (double?)20, ReservationId = 1 },
                   new { Id = 3, Name = "cut and brushing", Price = (double?)60, ReservationId = 2 },
                   new { Id = 4, Name = "coloring", Price = (double?)70, ReservationId = 2 }
                );
        }

        public DbSet<Reservation> Reservations { get; set; }
    }
}