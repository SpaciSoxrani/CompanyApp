using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using MusicApp;

namespace CompanyApp.Core;

public class TextClassificationService : IClassificationService
{
    private static MLContext _mlContext;
    private static string _appPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
    private static string _modelPath => Path.Combine(
        @"C:\Users\I553132\RiderProjects\CleanArchitecture\CompanyApp.Core\TextClassification\Model\model.zip");

    private static void UseModelWithSingleItem(MLContext mlContext, ITransformer model, string statement)
    {
        var predictionFunction = mlContext.Model.CreatePredictionEngine<CompanyText, IssuePrediction>(model);

        //Console.WriteLine("Write a new statement!");
            //var newSample = Console.ReadLine();
            CompanyText sampleStatement = new CompanyText
            {
                SentimentText = statement
            };

            var resultPrediction = predictionFunction.Predict(sampleStatement);

            Console.WriteLine();
            Console.WriteLine("=============== Prediction Test of model with a single sample and test dataset ===============");

            Console.WriteLine();
            Console.WriteLine($"Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} ");

            Console.WriteLine("=============== End of Predictions ===============");
            Console.WriteLine();
        
    }

    public void ClassificationTexts(string statement)
    {
        _mlContext = new MLContext(seed: 0);
        DataViewSchema modelSchema;
        ITransformer model = _mlContext.Model.Load(_modelPath, out modelSchema);

        
        UseModelWithSingleItem(_mlContext, model, statement);
    }
}