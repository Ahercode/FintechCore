namespace FintechCore.Application.Dtos.Setups;

public class UserDto : UpdateUserDto
{
    public int Id { get; set; }
    
    public int? Status { get; set; }

    public string? DateCreated { get; set; }
    
    public string? DateDisabled { get; set; }
}

public class CreateUserDto
{
    public required string Name { get; set; }
    
    public required string Username { get; set; }

    public int UserGroupId { get; set; }
    
    public required string BranchId { get; set; }
    
}

public class UpdateUserDto : CreateUserDto
{
    public int? Disabled { get; set; }
}