namespace FintechCore.Application.Dtos.Setups;

public class FormDto: UpdateFormDto
{
    public Guid FormId { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}

public class CreateFormDto
{
    public Guid CatId { get; set; }
    public required string FormName { get; set; }
    public string? Caption { get; set; }
    public string? Tooltip { get; set; }
    public bool? RequireVerification { get; set; }
    public string? VerifyEndpoint { get; set; }
    public string? ProcessEndpoint { get; set; }
    public int ?Rank { get; set; }
    public int? Status { get; set; }
    public string? StatusLabel { get; set; }
    public string? CreatedBy { get; set; }
    public string? InternalEndpoint { get; set; }
    public int? ApprovalLevel { get; set; }
    public int? AuthorizerAtBranch { get; set; }
    public int? VerifierAtBranch { get; set; }
    public int? ShowInBranch { get; set; }
    public string? ResponsibleRole { get; set; }
    public int? TermsOfUseType { get; set; }
    public string? TermsOfUseInfo { get; set; }
    public bool? RequireTermsOfUse { get; set; }
    public string? TermsOfUseTitle { get; set; }
}

public class UpdateFormDto: CreateFormDto
{
    public string? ModifiedBy { get; set; }
}