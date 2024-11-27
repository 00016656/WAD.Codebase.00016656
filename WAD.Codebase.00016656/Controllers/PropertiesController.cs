using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.Codebase._00016656.Dtos;
using WAD.Codebase._00016656.Models;
using WAD.Codebase._00016656.Services.Interfaces;

namespace WAD.Codebase._00016656.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> GetProperties()
        {
            var properties = await _propertyRepository.GetAllAsync();
            var propertyDTOs = _mapper.Map<List<PropertyDTO>>(properties);
            return Ok(propertyDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDTO>> GetPropertyById(int id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            if (property == null) return NotFound();

            var propertyDTO = _mapper.Map<PropertyDTO>(property);
            return Ok(propertyDTO);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> GetPropertiesByUserId(int userId)
        {
            var properties = await _propertyRepository.GetPropertiesByUserIdAsync(userId);
            var propertyDTOs = _mapper.Map<List<PropertyDTO>>(properties);
            return Ok(propertyDTOs);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProperty(CreatePropertyDTO createPropertyDTO)
        {
            var property = _mapper.Map<Property>(createPropertyDTO);
            property.ListedDate = DateTime.Now;

            await _propertyRepository.AddAsync(property);
            return CreatedAtAction(nameof(GetPropertyById), new { id = property.Id }, _mapper.Map<PropertyDTO>(property));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProperty(int id, PropertyDTO propertyDTO)
        {
            if (id != propertyDTO.Id) return BadRequest("Property ID mismatch");

            var property = await _propertyRepository.GetByIdAsync(id);
            if (property == null) return NotFound();

            _mapper.Map(propertyDTO, property);
            await _propertyRepository.UpdateAsync(property);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            if (property == null) return NotFound();

            await _propertyRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
