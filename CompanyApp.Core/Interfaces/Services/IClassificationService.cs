using CompanyApp.Core;
using CompanyApp.Core.Domain.Models;

namespace MusicApp;

public interface IClassificationService<T> where T : BaseEntity
{
    IssuePrediction? ClassificationTexts(T modelNews);
}