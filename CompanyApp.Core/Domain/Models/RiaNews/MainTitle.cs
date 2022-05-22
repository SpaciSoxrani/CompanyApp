namespace CompanyApp.Core.Domain.Models;

public class MainTitle : BaseEntity
{
    public Guid? Id { get; set; }
    public string? Name{ get; set; }
    
    public string Prediction { get; set; }
    public double Probability { get; set;  }
    
    public DateTime DateTime { get; set; }
    

    public MainTitle(string name, string prediction, double probability, DateTime dateTime)
    {
        Name = name;
        Prediction = prediction;
        Probability = probability;
        DateTime = dateTime;
    }
}