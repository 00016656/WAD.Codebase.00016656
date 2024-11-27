using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.Codebase._00016656.Dtos;
using WAD.Codebase._00016656.Models;
using WAD.Codebase._00016656.Services.Interfaces;

namespace WAD.Codebase._00016656.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var userDTOs = _mapper.Map<List<UserDTO>>(users);
            return Ok(userDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);
            user.PasswordHash = "SomethingToFillThis";

            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, _mapper.Map<UserDTO>(user));
        }

        [HttpGet("search")]
        public async Task<ActionResult<UserDTO>> SearchUserByEmail([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest("Email is required for searching.");

            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
                return NotFound($"No user found with email: {email}");

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            if (id != userDTO.Id) return BadRequest("User ID mismatch");

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            _mapper.Map(userDTO, user);
            await _userRepository.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
