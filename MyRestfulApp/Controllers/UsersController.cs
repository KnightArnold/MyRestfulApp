using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.Models;
using MyRestfulApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsersController : ControllerBase
    {
        private readonly IMyRestfulAppRepository _myRestfulAppRepository;
        private readonly IMapper _mapper;

        public UsersController(IMyRestfulAppRepository myRestfulAppRepository,
            IMapper mapper)
        {
            _myRestfulAppRepository = myRestfulAppRepository ?? throw new ArgumentNullException(nameof(myRestfulAppRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [HttpHead]
        public IActionResult GetUsers()
        {
            var usersFromRepo = _myRestfulAppRepository.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(usersFromRepo));
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(Guid userId)
        {
            var userFromRepo = _myRestfulAppRepository.GetUser(userId);

            if (userFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(userFromRepo));
        }
    }
}
