using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationFinder.DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetLocations([FromQuery] string keyword, [FromQuery] int radius, [FromQuery] string location)
        {
            try
            {
                var result = await _locationRepository.GetLocationData(keyword, radius, location);

                return result;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}