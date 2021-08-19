using Microsoft.EntityFrameworkCore;
using BarberApi.Models;
using System.Linq;

namespace BarberApi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BarberContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(BarberContext dbContext)
        {
            _context = dbContext;
            _customers = dbContext.Customers;
        }

        public Customer GetBy(string email)
        {
            return _customers.Include(c => c.Appointments).ThenInclude(f => f.Appointment).ThenInclude(r => r.Services).SingleOrDefault(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

