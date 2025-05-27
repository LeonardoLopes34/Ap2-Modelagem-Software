using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ap2.Controllers
{
    [ApiController]
    [Route("api/tutores")]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetAll() =>
            Ok(await _tutorRepository.getAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetById(int id)
        {
            try
            {
                var tutor = await _tutorRepository.getByIdAsync(id);
                return Ok(tutor);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new {message = $"Tutor com id {id} não encontrado."});
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Tutor>> GetByName(string name)
        {
            try
            {
                var tutor = await _tutorRepository.getByNameAsync(name);
                return Ok(tutor);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Tutor com nome {name} não encontrado." });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tutor>> Post(Tutor tutor)
        {
            try
            {
                var newTutor = await _tutorRepository.AddTutorAsync(tutor);
                return CreatedAtAction(nameof(GetById), new { id = newTutor.Id }, newTutor);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Tutor enviado não é valido.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tutorRepository.DeleteAsync(id);
                return Ok(new { message = "Tutor deletado com sucesso." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Tutor não encontrado." });
            }
        }
        [HttpPut]
        public async Task<ActionResult<Tutor>> Put(Tutor tutor)
        {
            try
            {
                await _tutorRepository.UpdateAsync(tutor);
                return Ok(new { message = $"Tutor '{tutor.Name}' atualizado com sucesso.", tutor }) ;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Tutor não encontrado" });
            }
        }
    }
}