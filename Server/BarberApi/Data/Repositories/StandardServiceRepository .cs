using Microsoft.EntityFrameworkCore;
using BarberApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BarberApi.Data.Repositories
{
    public class StandardServiceRepository : IStandardServiceRepository
    {
        private readonly BarberContext _context;
        private readonly DbSet<StandardService> _standardServices;

        public StandardServiceRepository(BarberContext dbContext)
        {
            _context = dbContext;
            _standardServices = dbContext.StandardServices;
        }

        public IEnumerable<StandardService> GetAll()
        {
            return _standardServices.ToList();
        }

        public IEnumerable<StandardService> GetAllInCategorie(string categorie)
        {
            return _standardServices.Where(r => r.Categorie.Equals(categorie)).ToList();
        }

        public StandardService GetBy(int id)
        {
            return _standardServices.SingleOrDefault(r => r.Id == id);
        }

        public bool TryGetStandardService(int id, out StandardService standardService)
        {
            standardService = _context.StandardServices.FirstOrDefault(t => t.Id == id);
            return standardService != null;
        }

        public void Add(StandardService standardService)
        {
            _standardServices.Add(standardService);
        }

        public void Update(StandardService standardService)
        {
            _context.Update(standardService);
        }

        public void Delete(StandardService standardService)
        {
            _standardServices.Remove(standardService);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<StandardService> GetBy(string name = null, double? price = null)
        {
            var standardServices = _standardServices.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                standardServices = standardServices.Where(r => r.Name.IndexOf(name) >= 0);
            if (price != null)
                standardServices = standardServices.Where(r => r.Price == price);
            return standardServices.OrderBy(r => r.Name).ToList();
        }
    }
}
