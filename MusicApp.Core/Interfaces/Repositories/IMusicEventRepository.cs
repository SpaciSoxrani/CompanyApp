using MusicApp.Core.Domain.Models;

namespace MusicApp.Core.Interfaces;

public interface IMusicEventRepository
{
    Task<MusicEvent> Create(MusicEvent musicEvent);
    Task<MusicEvent> FindByName(string musicEventName);
}