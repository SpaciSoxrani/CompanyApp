using CompanyApp.Core.Domain.Models;

namespace MusicApp.Infrastructure.Database.Repositories;

public interface IRepositoryDateGroup
{
    IEnumerable<NewsDateGroup?> GetAll();
    NewsDateGroup? GetById(Guid id);
    NewsDateGroup? GetByDate(DateTime dateTime);
    void Insert(NewsDateGroup? entity);
    void Update(NewsDateGroup entity);
    void Delete(Guid id);
}