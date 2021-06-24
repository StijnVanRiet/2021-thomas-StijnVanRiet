using System.ComponentModel.DataAnnotations;

namespace BarberApi.Models
{
    public class Service
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }
        #endregion

        #region Constructors
        public Service(string name, double? price = null)
        {
            Name = name;
            Price = price;
        }
        #endregion
    }
}