using DataAccess.Generic;
using Entities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IGenericRepository<City> _genericCityRepository;
        private readonly IGenericRepository<Country> _genericCountryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CityController(IGenericRepository<City> genericCityRepository, IGenericRepository<Country> genericCountryRepository, IUnitOfWork unitOfWork)
        {
            _genericCityRepository = genericCityRepository;
            _genericCountryRepository = genericCountryRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            return await _genericCityRepository.GetAsync();
        }

        [HttpGet("getcities/{countryId}")]
        public async Task<IEnumerable<City>> Get(int countryId)
        {
            return await _genericCityRepository.GetAsync(x => x.CountryId == countryId);
        }

        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _genericCityRepository.CreateAsync(city);

            if (created)
                _unitOfWork.Commit();

            return Created("Created", new { Response = StatusCode(201) });
        }
    }
}
