using Microsoft.AspNetCore.Identity;
using BarberApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BarberApi.Data
{
    public class BarberDataInitializer
    {
        private readonly BarberContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public BarberDataInitializer(BarberContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with appointments, see DBContext         
                Customer customer1 = new Customer { Email = "stijn.vanriet@student.hogent.be", FirstName = "Stijn", LastName = "Van Riet" };
                _dbContext.Customers.Add(customer1);
                customer1.AddAppointment(_dbContext.Appointments.First());
                await CreateUser(customer1.Email, "P@ssword1111");
                Customer customer2 = new Customer { Email = "mia.desmedt@mail.com", FirstName = "Mia", LastName = "De Smedt" };
                _dbContext.Customers.Add(customer2);
                customer2.AddAppointment(_dbContext.Appointments.Skip(1).First());
                await CreateUser(customer2.Email, "P@ssword1111");
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}

