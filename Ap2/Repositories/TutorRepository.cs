
using Microsoft.EntityFrameworkCore;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;

    public TutorRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Tutor> AddTutorAsync(Tutor tutor)
    {
        if (tutor == null)
        {
            throw new ArgumentNullException(nameof(tutor), "O tutor não pode ser nulo");
        }
        _context.Tutores.Add(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task DeleteAsync(int id)
    {
        var tutor = await getByIdAsync(id) ?? throw new KeyNotFoundException($"Tutor com ID {id} não foi encontrado.");
         _context.Tutores.Remove(tutor);
         await _context.SaveChangesAsync();
        
    }

    public async Task<IEnumerable<Tutor>> getAllAsync() =>
     await _context.Tutores.Include(p => p.Pets).ToListAsync();

    public async Task<Tutor> getByIdAsync(int id)
    {
        var tutor = await _context.Tutores.FindAsync(id) ?? throw new KeyNotFoundException($"Tutor com ID {id} não foi encontrado.");
        return tutor;
    }
    public async Task<Tutor> getByNameAsync(string? name)
    {
        var tutor = await _context.Tutores.FindAsync(name) ?? throw new KeyNotFoundException($"Tutor com o nome {name} não foi encontrado.");
        return tutor;
    }
    public async Task UpdateAsync(Tutor tutor)
    {
        var existingTutor = await _context.Tutores.FindAsync(tutor.Id) ?? throw new KeyNotFoundException($"Tutor com ID {tutor.Id} não foi encontrado para atualização.");
        _context.Entry(existingTutor).CurrentValues.SetValues(tutor);
        await _context.SaveChangesAsync();
    }
}