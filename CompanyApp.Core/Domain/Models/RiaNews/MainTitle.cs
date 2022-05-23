namespace CompanyApp.Core.Domain.Models;

public class MainTitle : BaseEntity
{
    public new Guid? Id { get; set; }
    public new string? Name{ get; set; }
    
    public new string Prediction { get; set; }
    public new double Probability { get; set;  }
    
    public new DateTime DateTime { get; set; }
    
    //public new Guid GroupDateId { get; set; }
    //public new Guid? NewsDateGroupId { get; set; }
    //public new NewsDateGroup NewsDateGroup { get; set; }

    public MainTitle(string name, string prediction, double probability, DateTime dateTime)
    {
        Name = name;
        Prediction = prediction;
        Probability = probability;
        DateTime = dateTime;
    }
}