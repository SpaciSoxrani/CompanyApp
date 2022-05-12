namespace CompanyApp.Core.Domain.Models;

public class MainTitle : BaseEntity
{
    public new Guid? Id { get; set; }
    public new string? Name{ get; set; }
    
    public new string Prediction { get; set; }
    public new double Probability { get; set;  }
}