using CompanyApp.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Infrastructure.Database.Repositories;

public class RepositoryDateNewsGroup<T> : IRepositoryDateGroup<T> where T : NewsDateGroup
{
    protected readonly CompanyAppContext context;
    private DbSet<T?> entities;
    string _errorMessage = string.Empty;
    
    public RepositoryDateNewsGroup(CompanyAppContext context)
    {
        this.context = context;
        entities = context.Set<T>();
    }

    
    public IEnumerable<T?> GetAll()
    {
        return entities.AsEnumerable();
    }

    public T? GetById(Guid id)
    {
        return entities.SingleOrDefault(s => s.Id == id);
    }

    public T? GetByDate(DateTime dateTime)
    {
        return entities.SingleOrDefault(s => s.DateTime == dateTime);
    }

    public void Insert(T? entity)
    {
        if (entity == null) throw new ArgumentNullException("entity");

        entities.Add(entity);
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity == null) throw new ArgumentNullException("entity");
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        if (id == null) throw new ArgumentNullException("entity");

        T? entity = entities.SingleOrDefault(s => s.Id == id);
        entities.Remove(entity);
        context.SaveChanges();
    }
}