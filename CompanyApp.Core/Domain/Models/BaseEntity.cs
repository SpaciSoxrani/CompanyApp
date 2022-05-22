namespace CompanyApp.Core.Domain.Models;

public class BaseEntity : IEntity
{
    public string? Id { get; set; }
    public string? Name { get; set; }

    public DateTime DateTime { get; set; }
}