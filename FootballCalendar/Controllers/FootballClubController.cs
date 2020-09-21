using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FootballСalendar.Entities;
using FootballСalendar.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace FootballСalendar.Controllers
{
    public class FootballClubController : Controller
    {

        private readonly ILogger<FootballClubController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FootballClubController(ILogger<FootballClubController> logger,
          ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            var list = _context.FootballClubs.Select(u => new FootballClubVM
            {
                Id = u.Id,
                Name = u.Name,
                Logo = "/Uploads/" + u.Logo,
                City = new CityVM { Name = u.City.Name },
                League = new LeageVM {Name = u.League.Name },
                HomeStadium = new StadiumVM {Name = u.HomeStadium.Name },
                Coach = new CoachVM {Name = u.Coach.Name, Surame = u.Coach.Surame }
            }).ToList(); ;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new FootballClubAddVM
            {
                Cities = new SelectList(_context.Cities, "Id", "Name"),
                Coaches = new SelectList(_context.Coaches, "Id", "Name"),
                Stadiums = new SelectList(_context.Stadiums, "Id", "Name"),
                Leagues = new SelectList(_context.Leagues, "Id", "Name")
                
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(FootballClubAddVM model)
        {
            if (ModelState.IsValid)
            {
                var serverPath = _env.ContentRootPath; //Directory.GetCurrentDirectory(); //_env.WebRootPath;
                var folerName = @"\wwwroot\Uploads\";
                //var path = Path.Combine(serverPath, folerName); //
                var path = serverPath + folerName; //
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string ext = Path.GetExtension(model.Logo.FileName);
                string fileName = Path.GetRandomFileName() + ext;

                string filePathSave = Path.Combine(path, fileName);

                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(filePathSave, FileMode.Create))
                {
                    await model.Logo.CopyToAsync(fileStream);
                }

                var fc = _context.FootballClubs.FirstOrDefault(c => c.Name == model.Name);
                if (fc == null)
                {
                    var result = _context.FootballClubs.Add
                        (new FootballClub
                        {
                            Name = model.Name,
                            Logo = fileName,
                            CityId = model.CityId,
                            HomeStadiumId = model.StadiumId,
                            CoachId = model.CoachId,
                            LeagueId = model.LeagueId,
                            DateCreate = DateTime.Now
                        });
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Дані вказано не коректно");
            return View(model);
        }

    }
}
