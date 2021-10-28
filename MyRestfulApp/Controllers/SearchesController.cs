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
    [Route("MyRestfulApp/busqueda")]
    public class SearchesController : ControllerBase
    {
        private readonly IMyRestfulAppRepository _myRestfulAppRepository;
        private readonly IMapper _mapper;

        public SearchesController(IMyRestfulAppRepository myRestfulAppRepository,
            IMapper mapper)
        {
            _myRestfulAppRepository = myRestfulAppRepository ?? throw new ArgumentNullException(nameof(myRestfulAppRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{termino}", Name = "termino")]
        public async Task<IActionResult> SearchTermQuery(string termino)
        {
            var termQueryFromRepo = await _myRestfulAppRepository.SearchTermQueryAsync(termino);

            if (termQueryFromRepo == null)
            {
                return NotFound();
            }

            return Ok(termQueryFromRepo);
        }
    }
}
