using CompanyApp.Core.Domain.Models;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Core.Interfaces;

public interface IRepositoryWrapper
{
    IRepository<MainTitle> Repository { get; }
    void Save();
}