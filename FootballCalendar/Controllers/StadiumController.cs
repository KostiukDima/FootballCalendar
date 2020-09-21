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
    public class StadiumController : Controller
    {
        private readonly ILogger<StadiumController> _logger;        
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public StadiumController(ILogger<StadiumController> logger,
          ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;           
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            var list = _context.Stadiums.Select(u => new StadiumVM
            {
                Id = u.Id,
                Name = u.Name,
                Capacity = u.Capacity,
                Image = "/Uploads/" + u.Image,
                CityVM = new CityVM { Name = u.City.Name }
            }).ToList(); ;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new StadiumAddVM { Cities = new SelectList(_context.Cities, "Id", "Name") });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StadiumAddVM model)
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
                string ext = Path.GetExtension(model.Image.FileName);
                string fileName = Path.GetRandomFileName() + ext;

                string filePathSave = Path.Combine(path, fileName);

                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(filePathSave, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                var stadium  = _context.Stadiums.FirstOrDefault(c => c.Name == model.Name);
                if (stadium == null)
                {
                    var result = _context.Stadiums.Add
                        (new Stadium
                        {
                            Name = model.Name,
                            Capacity = model.Capacity,
                            Image = fileName,
                            CityId = model.CityId,
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
