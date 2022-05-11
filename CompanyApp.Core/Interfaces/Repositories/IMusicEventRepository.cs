using CompanyApp.Core.Domain.Models;

namespace CompanyApp.Core.Interfaces;

public interface IMusicEventRepository
{
    Task<MusicEvent> Create(MusicEvent musicEvent);
    Task<MusicEvent> FindByName(string musicEventName);
}