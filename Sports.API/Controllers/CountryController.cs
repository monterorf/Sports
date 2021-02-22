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
    public class CountryController : ControllerBase
    {
        private readonly IGenericRepository<Country> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CountryController(IGenericRepository<Country> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            return await _genericRepository.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _genericRepository.CreateAsync(country);

            if (created)
                _unitOfWork.Commit();

            return Created("Created", new { Response = StatusCode(201) });
        }
    }
}
