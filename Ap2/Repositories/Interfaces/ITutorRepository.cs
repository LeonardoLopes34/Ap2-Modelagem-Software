public interface ITutorRepository 
{
    Task<IEnumerable<Tutor>> getAllAsync();
    Task<Tutor?> getByIdAsync(int Id);
    Task<Tutor?> getByNameAsync(String? name);
    Task<Tutor?> AddTutorAsync(Tutor tutor);
    Task UpdateAsync(Tutor tutor);
    Task DeleteAsync(int id);
}