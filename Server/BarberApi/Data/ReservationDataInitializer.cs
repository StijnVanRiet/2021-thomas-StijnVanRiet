using Microsoft.AspNetCore.Identity;

namespace BarberApi.Data
{
    public class ReservationDataInitializer
    {
        private readonly ReservationContext _dbContext;

        public ReservationDataInitializer(ReservationContext dbContext)
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

