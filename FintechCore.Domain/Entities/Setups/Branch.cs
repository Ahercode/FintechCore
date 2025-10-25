namespace FintechCore.Domain.Entities.Setups;

public class Branch
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? ShortName { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}