using BarberApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarberApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StandardServicesController : ControllerBase
    {
        private readonly IStandardServiceRepository _standardServiceRepository;

        public StandardServicesController(IStandardServiceRepository context)
        {
            _standardServiceRepository = context;
        }

        // GET: api/StandardServices
        /// <summary>
        /// Get all standard services 
        /// </summary>
        /// <returns>array of standard services </returns>
        [HttpGet]
        public IEnumerable<StandardService> GetStandardServices()
        {
            return _standardServiceRepository.GetAll();
        }

        // GET: api/StandardServices/5
        /// <summary>
        /// Get the standard service with given id
        /// </summary>
        /// <param name="id">the id of the standard service</param>
        /// <returns>The standard service</returns>
        [HttpGet("{id}")]
        public ActionResult<StandardService> GetStandardService(int id)
        {
            StandardService standardService = _standardServiceRepository.GetBy(id);
            if (standardService == null) return NotFound();
            return standardService;
        }

    }
}
