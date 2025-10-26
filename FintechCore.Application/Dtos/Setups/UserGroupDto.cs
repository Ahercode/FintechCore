namespace FintechCore.Application.Dtos.Setups;

public class UserGroupDto : UpdateUserGroupDto
{
    public int Id { get; set; }
    
    public DateTime? DateDisabled { get; set; }
}

public class CreateUserGroupDto
{
    public string? Name { get; set; }
}

public class UpdateUserGroupDto: CreateUserGroupDto
{
    public int? Disabled { get; set; }
}