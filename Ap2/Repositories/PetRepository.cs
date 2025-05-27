
using Ap2.Models.Dtos;
using Microsoft.EntityFrameworkCore;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Pet> AddPetAsync(Pet pet)
    {
        if (pet == null)
        {
            throw new ArgumentNullException(nameof(pet), "O pet não pode ser nulo.");
        }
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task DeleteAsync(int id)
    {
        var pet = await GetIdEntity(id) ?? throw new KeyNotFoundException($"Pet com ID {id} não encontrado.");
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<Pet> GetIdEntity(int Id)
    {
        var pet = await _context.Pets.Include(p => p.Tutor).FirstOrDefaultAsync(p => p.Id == Id) ?? throw new KeyNotFoundException($"Pet com ID {Id} não foi encontrado.");
        return pet;
    }

    public async Task<IEnumerable<PetDto>> GetAllAsync()
    {
        var pets = await _context.Pets.Include(p => p.Tutor).ToListAsync();
        return pets.Select(p => new PetDto
        {
            Id = p.Id,
            Name = p.Name,
            Specie = p.Specie,
            Race = p.Race,
            TutorId = p.TutorId,
            Tutor = new TutorDto
            {
                Id = p.Tutor.Id,
                Name = p.Tutor.Name,
                Telefone = p.Tutor.Telefone,
                Email = p.Tutor.Email
            }
        }
        );
    }


    public async Task<PetDto> GetByIdAsync(int Id)
    {
        var pet = await _context.Pets.Include(p => p.Tutor).FirstOrDefaultAsync(p => p.Id == Id) ?? throw new KeyNotFoundException($"Pet com ID {Id} não foi encontrado.");
        return new PetDto
        {
            Id = pet.Id,
            Name = pet.Name,
            Specie = pet.Specie,
            Race = pet.Race,
            TutorId = pet.TutorId,
            Tutor = new TutorDto
            {
                Id = pet.Tutor.Id,
                Name = pet.Tutor.Name,
                Telefone = pet.Tutor.Telefone,
                Email = pet.Tutor.Email
            }
        };
    }
    public async Task<PetDto> GetByNameAsync(string name)
    {
        var pet = await _context.Pets.Include(p => p.Tutor).FirstOrDefaultAsync(p => p.Name == name) ?? throw new KeyNotFoundException($"Pet com Nome {name} não foi encontrado");
        return new PetDto
        {
            Id = pet.Id,
            Name = pet.Name,
            Specie = pet.Specie,
            Race = pet.Race,
            TutorId = pet.TutorId,
            Tutor = new TutorDto
            {
                Id = pet.Tutor.Id,
                Name = pet.Tutor.Name,
                Telefone = pet.Tutor.Telefone,
                Email = pet.Tutor.Email
            }
        };
    }

    public async Task UpdateAsync(Pet pet)
    {
        var existingPet = await _context.Pets.FindAsync(pet.Id) ?? throw new KeyNotFoundException($"Pet com ID {pet.Id} não foi encontrado para atualização.");
        _context.Entry(existingPet).CurrentValues.SetValues(pet);
        await _context.SaveChangesAsync();
    }

}