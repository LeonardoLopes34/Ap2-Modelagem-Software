using Ap2.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ap2.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetAll()
        {
            var pets = await _petRepository.GetAllAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetById(int id)
        {
            try
            {
                var pet = await _petRepository.GetByIdAsync(id);
                return Ok(pet);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Pet com id {id} não encontrado." });
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Pet>> GetByName(string name)
        {
            try
            {
                var pet = await _petRepository.GetByNameAsync(name);
                return Ok(pet);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Pet com nome {name} não encontrado." });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> Post(Pet pet)
        {
            try
            {
                var newPet = await _petRepository.AddPetAsync(pet);
                return CreatedAtAction(nameof(GetById), new { id = newPet.Id }, newPet);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Pet enviado não é valido.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _petRepository.DeleteAsync(id);
                return Ok(new { message = "Pet deletado com sucesso." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Pet não encontrado" });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PetDto petDto)
        {
            try
            {
                // Buscar o pet original no banco
                var existingPet = await _petRepository.GetIdEntity(petDto.Id);

                // Atualizar os campos
                existingPet.Name = petDto.Name;
                existingPet.Specie = petDto.Specie;
                existingPet.Race = petDto.Race;
                existingPet.TutorId = petDto.TutorId;

                await _petRepository.UpdateAsync(existingPet);

                return Ok(new { message = $"Pet '{existingPet.Name}' atualizado com sucesso.", pet = petDto });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Pet não encontrado." });
            }
        }
    }
}