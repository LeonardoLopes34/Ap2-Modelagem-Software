
public class PetRepository : IPetRepository
{
    public Task<Pet> AddTutorAsync(Pet pet)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pet>> getAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Pet> getByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<Pet> getByNameAsync(string? name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Pet pet)
    {
        throw new NotImplementedException();
    }
}