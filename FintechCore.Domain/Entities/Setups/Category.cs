namespace FintechCore.Domain.Entities.Setups;

public class Category
{
    public string CatId { get; set; }
    public string CatName { get; set; }
    public string Description { get; set; }
    public string Tooltip { get; set; }
    public string Icon { get; set; }
    public string CustomCss { get; set; }
    public int Status { get; set; }
    public string StatusLabel { get; set; }
    public string DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public int Rank { get; set; }
    public string AllowedApp { get; set; }
    public string DateModified { get; set; }
    public string ModifiedBy { get; set; }
    public int ShowInBranch { get; set; }
}