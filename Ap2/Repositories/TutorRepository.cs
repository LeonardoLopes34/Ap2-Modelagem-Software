
using Microsoft.EntityFrameworkCore;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;

    public TutorRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Tutor?> AddTutorAsync(Tutor tutor)
    {
        _context.Tutores.Add(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task DeleteAsync(int id)
    {
        var tutor = await getByIdAsync(id);
        if (tutor == null) return;
        _context.Tutores.Remove(tutor);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Tutor>> getAllAsync() =>
     await _context.Tutores.ToListAsync();

    public async Task<Tutor?> getByIdAsync(int Id)
    {
        var tutor = await _context.Tutores.FindAsync(Id) ?? throw new KeyNotFoundException($"Tutor com ID {Id} não foi encontrado.");
        return tutor;
    }
    public async Task<Tutor?> getByNameAsync(string? name)
    {
        var tutor = await _context.Tutores.FindAsync(name) ?? throw new KeyNotFoundException($"Tutor com o nome {name} não foi encontrado.");
        return tutor;
    }
    public async Task UpdateAsync(Tutor tutor)
    {
        _context.Update(tutor);
        await _context.SaveChangesAsync();
    }
}