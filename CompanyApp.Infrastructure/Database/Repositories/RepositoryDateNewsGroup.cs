using CompanyApp.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MusicApp.Infrastructure.Database.Repositories;
using NuGet.Protocol.Core.Types;

namespace CompanyApp.Infrastructure.Database.Repositories;

public class RepositoryDateNewsGroup: IRepositoryDateGroup
{
    private readonly CompanyAppContext context;
    private DbSet<NewsDateGroup?> entities;
    string _errorMessage = string.Empty;
    
    public RepositoryDateNewsGroup(CompanyAppContext context)
    {
        this.context = context;
        entities = context.Set<NewsDateGroup>();
    }

    
    public IEnumerable<NewsDateGroup?> GetAll()
    {
        return entities.AsEnumerable();
    }

    public NewsDateGroup? GetById(Guid id)
    {
        return entities.SingleOrDefault(s => s.Id == id);
    }

    public NewsDateGroup? GetByDate(DateTime dateTime)
    {
        return entities.SingleOrDefault(s => s.DateTime == dateTime);
    }

    public void Insert(NewsDateGroup? entity)
    {
        if (entity == null) throw new ArgumentNullException("entity");

        entities.Add(entity);
        context.SaveChanges();
    }

    public void Update(NewsDateGroup entity)
    {
        if (entity == null) throw new ArgumentNullException("entity");
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        if (id == null) throw new ArgumentNullException("entity");

        NewsDateGroup? entity = entities.SingleOrDefault(s => s.Id == id);
        entities.Remove(entity);
        context.SaveChanges();
    }
}