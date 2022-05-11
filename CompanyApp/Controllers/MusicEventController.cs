#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyApp.Core.Domain.Models;
using CompanyApp.Infrastructure.Database;
using CompanyApp.Infrastructure.Database.Repositories;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicEventController : ControllerBase
    {
        private IRepository<MusicEvent> musicEventRepository;

        public MusicEventController(IRepository<MusicEvent> musicEventRepository)
        {
            this.musicEventRepository = musicEventRepository;
        }
        // public MusicEventController(MusicAppContext context)
        // {
        //     _context = context;
        // }
        
        [HttpGet]
        public IEnumerable<MusicEvent> GetMusicEvents() => musicEventRepository.GetAll();

        [HttpGet]
        [Route("{id}")]
        public MusicEvent GetMusicEventById(string id) => musicEventRepository.GetById(id);

        [HttpPost]
        [AllowAnonymous]
        public void AddMusicEvent([FromBody] MusicEvent musicEvent) => musicEventRepository.Insert(musicEvent);
        
        [HttpPut]
        [AllowAnonymous]
        public void UpdateMusicEvent([FromBody] MusicEvent musicEvent) => musicEventRepository.Update(musicEvent);

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public void DeleteMusicEvent(string id) => musicEventRepository.Delete(id);

    }
}
