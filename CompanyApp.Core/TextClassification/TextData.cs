using Microsoft.ML.Data;

namespace CompanyApp.Core;

public class CompanyText
{
    [LoadColumn(0)]
    public string SentimentText;

    [LoadColumn(1), ColumnName("Label")]
    public bool Sentiment;
}

//используется для прогнозирования после обучения модели.
public class IssuePrediction : CompanyText
{
    //cтолбец для прогнозирования

    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }
}