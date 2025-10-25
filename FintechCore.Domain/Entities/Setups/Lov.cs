namespace FintechCore.Domain.Entities.Setups;

public class Lov
{
    public Guid LovId { get; set; }
    public Guid FormId { get; set; }
    public Guid FieldId { get; set; }
    public string LovTitle { get; set; }
    public int? Status { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? CreatedBy { get; set; } 
    public DateTime? Mod { get; set; }
    public string LovValue { get; set; }
    public string? StatusLabel { get; set; }
    public string? ModifiedBy { get; set; }
    public int? Rank { get; set; }
}