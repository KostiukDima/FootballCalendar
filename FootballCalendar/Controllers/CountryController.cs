using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FootballСalendar.Entities;
using FootballСalendar.Models;
using FootballСalendar.Repo.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootballСalendar.Controllers
{
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryRepo _countryRepos;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CountryController(ILogger<CountryController> logger,
          ICountryRepo countryRepos, ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _countryRepos = countryRepos;
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            var list = _countryRepos.GetAll().Select(u => new CountryVM
            {
                Id = u.Id,
                Name = u.Name,
                Flag = "/Uploads/"+u.Flag
            }).ToList(); ;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CountryAddVM model)
        {
            if (ModelState.IsValid)
            {
                var serverPath = _env.ContentRootPath; //Directory.GetCurrentDirectory(); //_env.WebRootPath;
                var folerName = @"\wwwroot\Uploads\";
                //var path = Path.Combine(serverPath, folerName); //
                var path = serverPath+folerName; //
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string ext = Path.GetExtension(model.Flag.FileName);
                string fileName = Path.GetRandomFileName() + ext;

                string filePathSave = Path.Combine(path, fileName);

                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(filePathSave, FileMode.Create))
                {
                    await model.Flag.CopyToAsync(fileStream);
                }

                var country = _countryRepos.GetAll().FirstOrDefault(c => c.Name == model.Name);
                if (country == null)
                {
                    var result = _countryRepos.Create
                        (new Country
                        {
                            Name = model.Name,
                            Flag = fileName,
                            DateCreate = DateTime.Now
                        });

                }

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Дані вказано не коректно");
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            var country = _countryRepos.GetAll()
            .Select(u => new CountryEditVM
            {
                Id = u.Id,
                Name = u.Name,
                
            }).FirstOrDefault(c => c.Id == Id);

            return View(country);

        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(CountryEditVM model)
        {
            if (ModelState.IsValid)
            {
                var country = _countryRepos.GetAll().FirstOrDefault(c => c.Name == model.Name);
                if (country == null)
                {

                    var serverPath = _env.ContentRootPath; //Directory.GetCurrentDirectory(); //_env.WebRootPath;
                    var folerName = @"\wwwroot\Uploads\";
                    var path = serverPath+folerName; //

                    System.IO.File.Delete(Path.Combine(path, _countryRepos.GetById(model.Id).Flag));
                    
                        if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string ext = Path.GetExtension(model.Flag.FileName);
                    string fileName = Path.GetRandomFileName() + ext;

                    string filePathSave = Path.Combine(path, fileName);
                    
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(filePathSave, FileMode.Create))
                    {
                        await model.Flag.CopyToAsync(fileStream);
                    }

                    _countryRepos.Update(
                        new Country
                        {
                            Id = model.Id,
                            Name = model.Name,
                            Flag = fileName,
                            DateModify = DateTime.Now
                        });
                }

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Дані вказано не коректно");
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(long Id)
        {
            var country = _countryRepos.GetAll()
            .Select(u => new CountryVM
            {
                Id = u.Id,
                Flag = "/Uploads/" + u.Flag,
                Name = u.Name
            }).FirstOrDefault(c => c.Id == Id);

            return View(country);

        }

        [HttpPost]
        public IActionResult Delete(CountryVM model)
        {
            _countryRepos.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }


}

