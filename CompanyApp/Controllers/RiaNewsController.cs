#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyApp.Core;
using CompanyApp.Core.Domain.Models;
using CompanyApp.Infrastructure.Database;
using CompanyApp.Infrastructure.Database.Repositories;
using MusicApp.Infrastructure.Database.Repositories;
using NuGet.Protocol.Core.Types;

namespace CompanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiaNewsApi : ControllerBase
    {
        private readonly MusicAppContext _context;
        private IRepository<MainTitle> riaNewsRepository;

        public RiaNewsApi(IRepository<MainTitle> riaNewsRepository)
        {
            this.riaNewsRepository = riaNewsRepository;
        }
        
        // GET: api/RiaNewsApi
        [HttpGet]
        public IEnumerable<MainTitle> GetMainTitle() => riaNewsRepository.GetAll();

        [HttpPost]
        [AllowAnonymous]
        public void AddMainTitle([FromBody] MainTitle mainTitle)
        {
          riaNewsRepository.Insert(mainTitle);
        }

        [HttpGet]
        [Route("{id}")]
        public MainTitle GetById(string id) => riaNewsRepository.GetById(id);

        // public void AddParsedMainTitles()
        // {
        //     var mainTitles = HtmlParser.HtmlAgilityPackParse();
        //     foreach (var mainTitle in mainTitles)
        //     {
        //         riaNewsRepository.Insert(mainTitle);
        //     }
        // }
    }
}