using BarberApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BarberApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IStandardServiceRepository _standardServiceRepository;

        public CategoriesController(IStandardServiceRepository context)
        {
            _standardServiceRepository = context;
        }

        // GET: api/Categories
        /// <summary>
        /// Get all categories 
        /// </summary>
        /// <returns> array of categories </returns>
        [HttpGet]
        public IEnumerable<string> GetCategories()
        {
            List<string> categories = new List<string>();
            _standardServiceRepository.GetAll().ToList().ForEach(x => categories.Add(x.Categorie)); ;
            // remove duplicates
            categories = categories.Distinct().ToList();
            categories.Remove("Womenpricelist");
            categories.Remove("Menpricelist");
            categories.Remove("Studentspricelist");
            categories.Remove("Kidspricelist");
            return categories;
        }
    }
}