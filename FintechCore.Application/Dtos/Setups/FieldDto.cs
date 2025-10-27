namespace FintechCore.Application.Dtos.Setups;

public class FieldDto : UpdateFieldDto
{
    public Guid FieldId { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}

public class CreateFieldDto
{
    public Guid FormId { get; set; }
    public string? FieldName { get; set; }
    public string? FieldCaption { get; set; }
    public int? FieldType { get; set; }
    public int? FieldDataType { get; set; }
    public int? FieldLength { get; set; }
    public string? FieldDateFormat { get; set; }
    public int FieldMandatory { get; set; }
    public int FieldInRemarks { get; set; }
    public int Rank { get; set; }
    public int FieldVisible { get; set; }
    public string? DefaultValue { get; set; }
    public int? ReadOnly { get; set; }
    public int? ShowOnReceipt { get; set; }
    public int? IsAmount { get; set; }
    public int? RequiredForVerification { get; set; }
    public string? ToolTip { get; set; }
    public string? CreatedBy { get; set; }
    public int? Status { get; set; }
    public string? ThirdParty { get; set; }
    public string? StatusLabel { get; set; }
    public string? LovEndpoint { get; set; }
}

public class UpdateFieldDto : CreateFieldDto
{
    public string? ModifiedBy { get; set; }
}