using System.Text.Json.Serialization;

public class Pet
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Specie { get; set; }
    public required string Race { get; set; }
    public required int TutorId { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Tutor? Tutor { get; set; }
}