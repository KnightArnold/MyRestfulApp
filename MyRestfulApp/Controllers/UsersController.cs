using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    [Route("MyRestfulApp/usuarios")]
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
        public IActionResult GetUsers()
        {
            var usersFromRepo = _myRestfulAppRepository.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(usersFromRepo));
        }

        [HttpGet("{userId}", Name = "GetUsuario")]
        public IActionResult GetUser(Guid userId)
        {
            var userFromRepo = _myRestfulAppRepository.GetUser(userId);

            if (userFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(userFromRepo));
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserForCreationDto user)
        {
            var userEntity = _mapper.Map<Entities.User>(user);
            _myRestfulAppRepository.AddUser(userEntity);
            _myRestfulAppRepository.Save();

            var userToReturn = _mapper.Map<UserDto>(userEntity);
            return CreatedAtRoute("GetUsuario",
                new { userId = userToReturn.Id },
                userToReturn);
        }

        [HttpPut("{userId}")]
        public ActionResult UpdateUser(Guid userId,
            UserForUpdateDto user)
        { 
            if (!_myRestfulAppRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userFromRepo = _myRestfulAppRepository.GetUser(userId);

            if (userFromRepo == null)
            {
                return NotFound();
            }

            // map the entity to a UserForUpdateDto
            // apply the updated field values to that dto
            // map the UserForUpdateDto back to an entity
            _mapper.Map(user,userFromRepo);

            _myRestfulAppRepository.UpdateUser(userFromRepo);

            _myRestfulAppRepository.Save();

            return NoContent();
        }

        [HttpPatch("{userId}")]
        public ActionResult PartiallyUpdateUser(Guid userId,
            JsonPatchDocument<UserForUpdateDto> patchDocument)
        {
            if (!_myRestfulAppRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userFromRepo = _myRestfulAppRepository.GetUser(userId);

            if (userFromRepo == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserForUpdateDto>(userFromRepo);
            
            patchDocument.ApplyTo(userToPatch, ModelState);

            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userFromRepo);
            
            _myRestfulAppRepository.UpdateUser(userFromRepo);

            _myRestfulAppRepository.Save();

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(Guid userId)
        {
            if (!_myRestfulAppRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userFromRepo = _myRestfulAppRepository.GetUser(userId);

            if (userFromRepo == null)
            {
                return NotFound();
            }

            _myRestfulAppRepository.DeleteUser(userFromRepo);
            _myRestfulAppRepository.Save();

            return NoContent();
        }
    }
}
