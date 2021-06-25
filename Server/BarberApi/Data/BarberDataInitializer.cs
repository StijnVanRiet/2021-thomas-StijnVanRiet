using Microsoft.AspNetCore.Identity;

namespace BarberApi.Data
{
    public class BarberDataInitializer
    {
        private readonly BarberContext _dbContext;

        public BarberDataInitializer(BarberContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with reservations, see DBContext               
            }
        }

    }
}

