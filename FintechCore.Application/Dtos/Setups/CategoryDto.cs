namespace FintechCore.Application.Dtos.Setups;

public class CategoryDto : UpdateCategoryDto
{
    public Guid CatId { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}

public class CreateCategoryDto
{
    public string CatName { get; set; }
    public string? Description { get; set; }
    public string? Tooltip { get; set; }
    public string? Icon { get; set; }
    public string? CustomCss { get; set; }
    public int? Status { get; set; }
    public string? StatusLabel { get; set; }
    public string? CreatedBy { get; set; }
    public int? Rank { get; set; }
    public string? AllowedApp { get; set; }
    public int? ShowInBranch { get; set; }
}

public class UpdateCategoryDto : CreateCategoryDto
{

    public string? ModifiedBy { get; set; }
}