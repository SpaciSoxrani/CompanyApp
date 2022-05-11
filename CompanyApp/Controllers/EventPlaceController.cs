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
    public class EventPlaceController : ControllerBase
    {
        private readonly MusicAppContext _context;
        
        private IRepository<EventPlace> eventPlaceRepository;

        public EventPlaceController(IRepository<EventPlace> eventPlaceRepository)
        {
            this.eventPlaceRepository = eventPlaceRepository;
        }

        // public EventPlaceController(MusicAppContext context)
        // {
        //     _context = context;
        // }
        
        [HttpGet] 
        public IEnumerable<EventPlace> GetEventPlace() => eventPlaceRepository.GetAll();

        [HttpGet]
        [Route("{id}")]
        public EventPlace GetEventPlace(string id) => eventPlaceRepository.GetById(id);

        [HttpPut]
        [AllowAnonymous]
        public void UpdateEventPlace([FromBody] EventPlace eventPlace) => eventPlaceRepository.Update(eventPlace);
        
        [HttpPost]
        [AllowAnonymous]
        public void AddEventPlace([FromBody] EventPlace eventPlace) => eventPlaceRepository.Insert(eventPlace);

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public void DeleteEventPlace(string id) => eventPlaceRepository.Delete(id);
        
    }
}
