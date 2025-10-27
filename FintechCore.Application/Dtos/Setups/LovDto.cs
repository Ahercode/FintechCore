namespace FintechCore.Application.Dtos.Setups;

public class LovDto : UpdateLovDto
{
    public Guid LovId { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}

public class CreateLovDto
{
    public Guid FormId { get; set; }
    public Guid FieldId { get; set; }
    public string LovTitle { get; set; }
    public int? Status { get; set; }
    public string? CreatedBy { get; set; }  
    public string LovValue { get; set; }
    public string? StatusLabel { get; set; }
    public int? Rank { get; set; }
}

public class UpdateLovDto : CreateLovDto
{
    public string? ModifiedBy { get; set; }
}