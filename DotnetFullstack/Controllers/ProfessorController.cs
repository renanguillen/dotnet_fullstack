using DotnetFullstack.Domain.Entities;
using DotnetFullstack.Domain.Services;
using DotnetFullstack.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DotnetFullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorService _service;

        public ProfessorController(ProfessorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessores()
        {
            var professores = await _service.GetAllAsync();
            if (professores == null || !professores.Any())
                return NoContent();

            return Ok(professores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(Guid id)
        {
            var professor = await _service.GetByIdAsync(id);
            if (professor == null)
                return NotFound(new { message = "Professor not found." });

            return Ok(professor);
        }


        [HttpPost]
        public async Task<ActionResult> PostProfessor([FromBody] ProfessorCreateDto professorDto)
        {
            if (string.IsNullOrWhiteSpace(professorDto.Name) || string.IsNullOrWhiteSpace(professorDto.Biography))
                return BadRequest(new { message = "Name and biography are required." });

            await _service.AddAsync(professorDto.Name, professorDto.Biography);
            return CreatedAtAction(nameof(GetProfessores), new { message = "Professor created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(Guid id, [FromBody] ProfessorUpdateDto professorDto)
        {
            var professor = await _service.GetByIdAsync(id);
            if (professor == null)
                return NotFound(new { message = "Professor not found." });

            await _service.UpdateAsync(id, professorDto.Name, professorDto.Biography);
            return Ok(new { message = "Professor updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(Guid id)
        {
            var professor = await _service.GetByIdAsync(id);
            if (professor == null)
                return NotFound(new { message = "Professor not found." });

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
