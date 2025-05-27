
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
        var pet = await getByIdAsync(id) ?? throw new KeyNotFoundException($"Pet com ID {id} não encontrado.");
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Pet>> getAllAsync() =>
        await _context.Pets.Include(p => p.Tutor).ToListAsync();

    public async Task<Pet> getByIdAsync(int Id)
    {
        var pet = await _context.Pets.Include(p => p.Tutor).FirstOrDefaultAsync(p => p.Id == Id) ?? throw new KeyNotFoundException($"Pet com ID {Id} não foi encontrado.");
        return pet;
    }
    public async Task<Pet> getByNameAsync(string name)
    {
        var pet = await _context.Pets.Include(p => p.Tutor).FirstOrDefaultAsync(p => p.Name == name) ?? throw new KeyNotFoundException($"Pet com Nome {name} não foi encontrado");
        return pet;
    }

    public async Task UpdateAsync(Pet pet)
    {
        var existingPet = await _context.Pets.FindAsync(pet.Id) ?? throw new KeyNotFoundException($"Pet com ID {pet.Id} não foi encontrado para atualização.");
        _context.Entry(existingPet).CurrentValues.SetValues(pet);
        await _context.SaveChangesAsync();
    }

}