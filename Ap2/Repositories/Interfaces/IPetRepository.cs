public interface IPetRepository 
{
    Task<IEnumerable<Pet>> getAllAsync();
    Task<Pet> getByIdAsync(int Id);
    Task<Pet> getByNameAsync(String? name);
    Task<Pet> AddTutorAsync(Pet pet);
    Task UpdateAsync(Pet pet);
    Task DeleteAsync(int id);
}