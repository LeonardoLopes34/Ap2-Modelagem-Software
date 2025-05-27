public interface IPetRepository 
{
    Task<IEnumerable<Pet>> getAllAsync();
    Task<Pet> getByIdAsync(int Id);
    Task<Pet> getByNameAsync(string name);
    Task<Pet> AddPetAsync(Pet pet);
    Task UpdateAsync(Pet pet);
    Task DeleteAsync(int id);
}