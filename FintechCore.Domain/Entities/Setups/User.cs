namespace FintechCore.Domain.Entities.Setups;

public class User
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Username { get; set; }
    
    public string? Password { get; set; }

    public int? UserGroupId { get; set; }
    
    public int? BranchId { get; set; }

    public int? Status { get; set; }

    public DateTime? DateCreated { get; set; }
    
    public DateTime? DateDisabled { get; set; }

    public int? Disabled { get; set; }
}
