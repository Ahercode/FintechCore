namespace FintechCore.Domain.Entities.Setups;


public class UserGroup
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public int? Disabled { get; set; }
    
    public DateTime? DateDisabled { get; set; }
}
