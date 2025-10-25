namespace FintechCore.Application.Dtos.Setups;

public class BranchDto : UpdateBranchDto
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateBranchDto
{
    public string? Code { get; set; }
    public string? ShortName { get; set; }
    public string Name { get; set; }
}

public class UpdateBranchDto : CreateBranchDto
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}