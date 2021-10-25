using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.Controllers
{
    [ApiController]
    [Route("api/paises")]
    public class CountriesController : ControllerBase
    {
        private readonly IMyRestfulAppRepository _myRestfulAppRepository;
        private readonly IMapper _mapper;

        public CountriesController(IMyRestfulAppRepository myRestfulAppRepository,
            IMapper mapper)
        {
            _myRestfulAppRepository = myRestfulAppRepository ?? throw new ArgumentNullException(nameof(myRestfulAppRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetCountries()
        {
            var countriesFromRepo = await _myRestfulAppRepository.GetCountriesAsync();
            
            if (countriesFromRepo == null)
            {
                return NotFound();
            }

            return Ok(countriesFromRepo);
        }


        [HttpGet("{countryId}", Name = "GetPais")]
        public async Task<IActionResult> GetCountry(string countryId)
        {
            if (countryId == "BR" || countryId == "CO")
            {
                return Unauthorized();
            }

            var countryFromRepo = await _myRestfulAppRepository.GetCountryAsync(countryId);

            if (countryFromRepo == null)
            {                
                return NotFound();
            }

            return Ok(countryFromRepo);
        }
    }
}
