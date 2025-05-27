using System.Text.Json.Serialization;

public class Tutor
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public ICollection<Pet>? Pets { get; set; }
}