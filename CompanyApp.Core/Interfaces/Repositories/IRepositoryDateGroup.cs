using CompanyApp.Core.Domain.Models;

namespace MusicApp.Infrastructure.Database.Repositories;

public interface IRepositoryDateGroup<T> where T : BaseEntity
{
    IEnumerable<T?> GetAll();
    T? GetById(Guid id);
    T? GetByDate(DateTime dateTime);
    void Insert(T? entity);
    void Update(T entity);
    void Delete(Guid id);
}