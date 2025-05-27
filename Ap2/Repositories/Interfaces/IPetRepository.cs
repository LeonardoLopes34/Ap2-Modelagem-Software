using Ap2.Models.Dtos;

public interface IPetRepository 
{
    Task<IEnumerable<PetDto>> GetAllAsync();
    Task<PetDto> GetByIdAsync(int Id);
    Task<Pet> GetIdEntity(int Id);
    Task<PetDto> GetByNameAsync(string name);
    Task<Pet> AddPetAsync(Pet pet);
    Task UpdateAsync(Pet pet);
    Task DeleteAsync(int id);
}