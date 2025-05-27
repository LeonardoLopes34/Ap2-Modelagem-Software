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
            var pets = await _petRepository.getAllAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetById(int id)
        {
            try
            {
                var pet = await _petRepository.getByIdAsync(id);
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
                var pet = await _petRepository.getByNameAsync(name);
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

        [HttpDelete ("{id}")]
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
        public async Task<ActionResult<Pet>> Put(Pet pet)
        {
            try
            {
                await _petRepository.UpdateAsync(pet);
                return Ok(new { message = $"Pet '{pet.Name}' atualizado com sucesso. ", pet });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Pet não encontrado." });
            }
        }
    }
}