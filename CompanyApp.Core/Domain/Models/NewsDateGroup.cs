namespace CompanyApp.Core.Domain.Models;

public class NewsDateGroup : BaseEntity
{
    public new Guid? Id { get; set; }
    public new string? Name{ get; set; }
    public DateTime DateTime { get; set; }
}