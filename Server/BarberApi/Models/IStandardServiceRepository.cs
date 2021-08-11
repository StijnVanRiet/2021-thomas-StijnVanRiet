using System.Collections.Generic;

namespace BarberApi.Models
{
    public interface IStandardServiceRepository
    {
        StandardService GetBy(int id);
        bool TryGetStandardService(int id, out StandardService standardService);
        IEnumerable<StandardService> GetAll();
        IEnumerable<StandardService> GetBy(string name = null, double? price = null);
        void Add(StandardService standardService);
        void Delete(StandardService standardService);
        void Update(StandardService standardService);
        void SaveChanges();
        IEnumerable<StandardService> GetAllInCategorie(string categorie);
    }
}

