using System.Linq;
using Microsoft.EntityFrameworkCore;
using CompanyApp.Core.Domain.Models;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Infrastructure.Database.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly CompanyAppContext context;
    private DbSet<T> entities;
    string _errorMessage = string.Empty;
    
    public Repository(CompanyAppContext context)
    {
        this.context = context;
        entities = context.Set<T>();
    }

    public IEnumerable<T?> GetAll()
    {
        return entities.AsEnumerable();
    }

    public T? GetById(string id)
    {
        return entities.SingleOrDefault(s => s.Id == id);
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
    
    public void Delete(string id)
    {
        if (id == null) throw new ArgumentNullException("entity");

        T? entity = entities.SingleOrDefault(s => s.Id == id);
        entities.Remove(entity);
        context.SaveChanges();
    }
}