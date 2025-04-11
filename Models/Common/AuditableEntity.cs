
namespace ContactsApi.AuditableModel;
public class BaseAuditableEntity
{
    public DateTime CreateAt { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string UpdateBy { get; set; }
}

public class BaseFullEntity : BaseAuditableEntity
{
    public required bool Status { get; set; }

}