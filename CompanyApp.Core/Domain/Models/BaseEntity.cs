namespace CompanyApp.Core.Domain.Models;

public class BaseEntity : IEntity
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public new string Prediction { get; set; }
    public new double Probability { get; set;  }
}