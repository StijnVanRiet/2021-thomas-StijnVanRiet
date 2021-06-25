using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BarberApi.Models
{
    public class StandardService
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }
        #endregion

        #region Constructors
        public StandardService()
        {

        }
        public StandardService(string name, double? price = null) : this()
        {
            Name = name;
            Price = price;
        }
        #endregion
    }
}
