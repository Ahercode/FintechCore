namespace FintechCore.Domain.Entities.Setups;

public class Lov
{
    public string LovId { get; set; }
    public string FormId { get; set; }
    public string FieldId { get; set; }
    public string LovTitle { get; set; }
    public int? Status { get; set; }
    public DateTime? DateCreated { get; set; }
    public string LovValue { get; set; }
    public string? StatusLabel { get; set; }
    public string? ModifiedBy { get; set; }
    public int? Rank { get; set; }
}