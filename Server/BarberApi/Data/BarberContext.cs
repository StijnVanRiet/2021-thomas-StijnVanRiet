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
                    Name = "Cut",
                    Price = (double?)44,
                    Categorie = "Women"
                },
                new StandardService
                {
                    Id = 2,
                    Name = "Brush",
                    Price = (double?)39,
                    Categorie = "Women"
                },
                new StandardService
                {
                    Id = 3,
                    Name = "Cut & brush",
                    Price = (double?)64,
                    Categorie = "Women"
                },
                new StandardService
                {
                    Id = 4,
                    Name = "Make up",
                    Price = (double?)48,
                    Categorie = "Women"
                },
                new StandardService
                {
                    Id = 5,
                    Name = "Coloring",
                    Price = (double?)71,
                    Categorie = "Women"
                }, new StandardService
                {
                    Id = 6,
                    Name = "Cut & styling",
                    Price = (double?)38,
                    Categorie = "Men"
                },
                new StandardService
                {
                    Id = 7,
                    Name = "Trim cut",
                    Price = (double?)29,
                    Categorie = "Men"
                },
                new StandardService
                {
                    Id = 8,
                    Name = "Special cut",
                    Price = (double?)45,
                    Categorie = "Men"
                },
                new StandardService
                {
                    Id = 9,
                    Name = "Coloring",
                    Price = (double?)46,
                    Categorie = "Men"
                },
                new StandardService
                {
                    Id = 10,
                    Name = "Quick shave",
                    Price = (double?)26,
                    Categorie = "Men"
                },
                new StandardService
                {
                    Id = 11,
                    Name = "Complete shave",
                    Price = (double?)32,
                    Categorie = "Men"
                },
                new StandardService
                {
                    Id = 12,
                    Name = "Head shave",
                    Price = (double?)36,
                    Categorie = "Men"
                },
                new StandardService
                {
                    Id = 13,
                    Name = "Cut & brush female",
                    Price = (double?)51,
                    Categorie = "Students"
                },
                new StandardService
                {
                    Id = 14,
                    Name = "Coloring female",
                    Price = (double?)56,
                    Categorie = "Students"
                },
                new StandardService
                {
                    Id = 15,
                    Name = "Cut & styling male",
                    Price = (double?)31,
                    Categorie = "Students"
                },
                new StandardService
                {
                    Id = 16,
                    Name = "Coloring male",
                    Price = (double?)41,
                    Categorie = "Students"
                },
                new StandardService
                {
                    Id = 17,
                    Name = "Girls - 0 t/m 7",
                    Price = (double?)26,
                    Categorie = "Kids"
                },
                new StandardService
                {
                    Id = 18,
                    Name = "Girls - 8 t/m 12",
                    Price = (double?)33,
                    Categorie = "Kids"
                },
                new StandardService
                {
                    Id = 19,
                    Name = "Girls - 13 t/m 18",
                    Price = (double?)43,
                    Categorie = "Kids"
                },
                new StandardService
                {
                    Id = 20,
                    Name = "Boys - 0 t/m 7",
                    Price = (double?)23,
                    Categorie = "Kids"
                },
                new StandardService
                {
                    Id = 21,
                    Name = "Boys - 8 t/m 12",
                    Price = (double?)27,
                    Categorie = "Kids"
                },
                new StandardService
                {
                    Id = 22,
                    Name = "Boys - 13 t/m 18",
                    Price = (double?)30,
                    Categorie = "Kids"
                },
                new StandardService
                {
                    Id = 101,
                    Name = "Cut & brush - short",
                    Price = (double?)62,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 102,
                    Name = "Cut & brush - medium",
                    Price = (double?)64,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 103,
                    Name = "Cut & brush - long",
                    Price = (double?)66,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 104,
                    Name = "Only cut (no drying)",
                    Price = (double?)44,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 105,
                    Name = "Brush - short",
                    Price = (double?)37,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 106,
                    Name = "Brush - medium",
                    Price = (double?)39,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 107,
                    Name = "Brush - long",
                    Price = (double?)44,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 108,
                    Name = "Curling iron finish",
                    Price = (double?)9,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 109,
                    Name = "Long hair full curling iron",
                    Price = (double?)40,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 110,
                    Name = "Hair straightener finish",
                    Price = (double?)9,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 111,
                    Name = "Epilate eyebrows",
                    Price = (double?)10,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 112,
                    Name = "Coloring eyebrows",
                    Price = (double?)10,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 113,
                    Name = "Make up",
                    Price = (double?)48,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 114,
                    Name = "Coloring roots",
                    Price = (double?)55,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 115,
                    Name = "Hair bleaching",
                    Price = (double?)62,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 116,
                    Name = "Locks & foils - short",
                    Price = (double?)61,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 117,
                    Name = "Locks & foils - medium",
                    Price = (double?)70,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 118,
                    Name = "Locks & foils - long",
                    Price = (double?)86,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 119,
                    Name = "Locks extra coloring",
                    Price = (double?)19,
                    Categorie = "Womenpricelist"
                },
                new StandardService
                {
                    Id = 120,
                    Name = "Cut & styling",
                    Price = (double?)38,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 121,
                    Name = "Special cut",
                    Price = (double?)45,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 122,
                    Name = "Trim cut",
                    Price = (double?)29,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 123,
                    Name = "Brush",
                    Price = (double?)24,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 124,
                    Name = "Lotion",
                    Price = (double?)8,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 125,
                    Name = "Quick shave",
                    Price = (double?)26,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 126,
                    Name = "Complete shave",
                    Price = (double?)32,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 127,
                    Name = "Head shave",
                    Price = (double?)36,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 128,
                    Name = "Coloring",
                    Price = (double?)46,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 129,
                    Name = "Half coloring",
                    Price = (double?)29,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 130,
                    Name = "Extra coloring",
                    Price = (double?)18,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 131,
                    Name = "Locks with foils",
                    Price = (double?)44,
                    Categorie = "Menpricelist"
                },
                new StandardService
                {
                    Id = 132,
                    Name = "Cut & brush female",
                    Price = (double?)51,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 133,
                    Name = "Coloring female - short",
                    Price = (double?)51,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 134,
                    Name = "Coloring female - long",
                    Price = (double?)61,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 135,
                    Name = "Locks female - short",
                    Price = (double?)49,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 136,
                    Name = "Locks female - medium",
                    Price = (double?)63,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 137,
                    Name = "Locks female - long",
                    Price = (double?)76,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 138,
                    Name = "Shadow root",
                    Price = (double?)61,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 139,
                    Name = "Toner",
                    Price = (double?)28,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 140,
                    Name = "Cut & styling male",
                    Price = (double?)31,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 141,
                    Name = "Coloring male",
                    Price = (double?)41,
                    Categorie = "Studentspricelist"
                },
                new StandardService
                {
                    Id = 142,
                    Name = "Girls - 0 t/m 7",
                    Price = (double?)26,
                    Categorie = "Kidspricelist"
                },
                new StandardService
                {
                    Id = 143,
                    Name = "Girls - 8 t/m 12",
                    Price = (double?)33,
                    Categorie = "Kidspricelist"
                },
                new StandardService
                {
                    Id = 144,
                    Name = "Girls - 13 t/m 18",
                    Price = (double?)43,
                    Categorie = "Kidspricelist"
                },
                new StandardService
                {
                    Id = 145,
                    Name = "Boys - 0 t/m 7",
                    Price = (double?)23,
                    Categorie = "Kidspricelist"
                },
                new StandardService
                {
                    Id = 146,
                    Name = "Boys - 8 t/m 12",
                    Price = (double?)27,
                    Categorie = "Kidspricelist"
                },
                new StandardService
                {
                    Id = 147,
                    Name = "Boys - 13 t/m 18",
                    Price = (double?)30,
                    Categorie = "Kidspricelist"
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
                     FirstName = "Jan",
                     LastName = "Vermorgen",
                     PhoneNumber = "0466666666",
                     Email = "jan.vermorgen@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 8, 45, 0),
                 },
                 new Appointment
                 {
                     Id = 3,
                     FirstName = "Jolien",
                     LastName = "Van Keer",
                     PhoneNumber = "0455555555",
                     Email = "Jolien.vankeer@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 9, 30, 0),
                 },
                 new Appointment
                 {
                     Id = 4,
                     FirstName = "Mieke",
                     LastName = "Schellemans",
                     PhoneNumber = "0444444444",
                     Email = "mieke.schellemans@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 10, 15, 0),
                 },
                 new Appointment
                 {
                     Id = 5,
                     FirstName = "Kevin",
                     LastName = "De Bruyne",
                     PhoneNumber = "0433333333",
                     Email = "kevin.debruyne@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 11, 0, 0),
                 },
                 new Appointment
                 {
                     Id = 6,
                     FirstName = "Lewis",
                     LastName = "Hamilton",
                     PhoneNumber = "0422222222",
                     Email = "lewis.hamilton@mail.be",
                     Remarks = "Only natural products please",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 11, 45, 0),
                 },
                 new Appointment
                 {
                     Id = 7,
                     FirstName = "Jack",
                     LastName = "Black",
                     PhoneNumber = "0411111111",
                     Email = "jack.black@mail.com",
                     Remarks = "A remark.",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 13, 0, 0),
                 },
                 new Appointment
                 {
                     Id = 8,
                     FirstName = "May",
                     LastName = "Weathers",
                     PhoneNumber = "0400000000",
                     Email = "may.weathers@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 13, 45, 0),
                 },
                 new Appointment
                 {
                     Id = 9,
                     FirstName = "Lies",
                     LastName = "Van Buggenhout",
                     PhoneNumber = "0499999999",
                     Email = "lies.vanbuggenhout@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 14, 30, 0),
                 },
                 new Appointment
                 {
                     Id = 10,
                     FirstName = "Stefaan",
                     LastName = "De Man",
                     PhoneNumber = "0488888888",
                     Email = "stefaan.deman@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 15, 15, 0),
                 },
                 new Appointment
                 {
                     Id = 11,
                     FirstName = "Ingrid",
                     LastName = "Van Malderen",
                     PhoneNumber = "04777777777",
                     Email = "ingrid.vanmalderen@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 16, 0, 0),
                 },
                 new Appointment
                 {
                     Id = 12,
                     FirstName = "Karen",
                     LastName = "Nieuwland",
                     PhoneNumber = "0412121212",
                     Email = "karen.nieuwland@mail.be",
                     Remarks = "",
                     Date = new DateTime(2021, 08, DateTime.Now.Day + 2, 16, 45, 0),
                 },
                  new Appointment
                  {
                      Id = 13,
                      FirstName = "Jef",
                      LastName = "Breedland",
                      PhoneNumber = "0423232323",
                      Email = "jef.breedland@mail.be",
                      Remarks = "",
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
                   new { Id = 1, Name = "Trim cut", Price = (double?)29, AppointmentId = 1 },
                   new { Id = 2, Name = "Quick shave", Price = (double?)26, AppointmentId = 1 },
                   new { Id = 3, Name = "Complete shave", Price = (double?)32, AppointmentId = 2 },
                   new { Id = 4, Name = "Make up", Price = (double?)48, AppointmentId = 3 },
                   new { Id = 5, Name = "Brush", Price = (double?)39, AppointmentId = 4 },
                   new { Id = 6, Name = "Special cut", Price = (double?)45, AppointmentId = 5 },
                   new { Id = 7, Name = "Quick shave", Price = (double?)26, AppointmentId = 6 },
                   new { Id = 8, Name = "Head shave", Price = (double?)36, AppointmentId = 7 },
                   new { Id = 9, Name = "Cut", Price = (double?)44, AppointmentId = 8 },
                   new { Id = 10, Name = "Cut and brush", Price = (double?)64, AppointmentId = 9 },
                   new { Id = 11, Name = "Cut & styling", Price = (double?)38, AppointmentId = 10 },
                   new { Id = 12, Name = "Brush", Price = (double?)39, AppointmentId = 11 },
                   new { Id = 13, Name = "Make up", Price = (double?)48, AppointmentId = 11 },
                   new { Id = 14, Name = "Cut and brush", Price = (double?)64, AppointmentId = 12 },
                   new { Id = 15, Name = "Complete shave", Price = (double?)32, AppointmentId = 13 },
                   new { Id = 16, Name = "Cut and brush", Price = (double?)64, AppointmentId = 14 },
                   new { Id = 17, Name = "Coloring", Price = (double?)71, AppointmentId = 14 }
                );
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<StandardService> StandardServices { get; set; }
    }
}