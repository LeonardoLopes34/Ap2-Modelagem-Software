
public class TutorRepository : ITutorRepository
{
    public Task<Tutor> AddTutorAsync(Tutor tutor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Tutor>> getAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tutor> getByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<Tutor> getByNameAsync(string? name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Tutor tutor)
    {
        throw new NotImplementedException();
    }
}