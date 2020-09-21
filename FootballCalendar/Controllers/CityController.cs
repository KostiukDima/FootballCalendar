using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballСalendar.Entities;
using FootballСalendar.Models;
using FootballСalendar.Repo.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace FootballСalendar.Controllers
{
    public class CityController : Controller
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityRepo _cityRepos;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CityController(ILogger<CityController> logger,
          ICityRepo cityRepos, ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _cityRepos = cityRepos;
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            var list = _cityRepos.GetAll().Select(u => new CityVM
            {
                Id = u.Id,
                Name = u.Name,
                Country = new CountryVM { Name = u.Country.Name, Flag = "/Uploads/"+u.Country.Flag }
            }).ToList(); ;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new CityAddVM { Countries = new SelectList(_context.Countries, "Id", "Name") });
        }

        [HttpPost]
        public IActionResult Create(CityAddVM model)
        {
            if (ModelState.IsValid)
            {
                

                var country = _cityRepos.GetAll().FirstOrDefault(c => c.Name == model.Name);
                if (country == null)
                {
                    var result = _cityRepos.Create
                        (new City
                        {
                            Name = model.Name,
                            CountryId = model.CountryId,
                            DateCreate = DateTime.Now
                        });

                }

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Дані вказано не коректно");
            return View(model);
        }

        //    [HttpGet]
        //    public IActionResult Edit(long Id)
        //    {
        //        var country = _cityRepos.GetAll()
        //        .Select(u => new CountryEditVM
        //        {
        //            Id = u.Id,
        //            Name = u.Name,

        //        }).FirstOrDefault(c => c.Id == Id);

        //        return View(country);

        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> EditAsync(CountryEditVM model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var country = _countryRepos.GetAll().FirstOrDefault(c => c.Name == model.Name);
        //            if (country == null)
        //            {

        //                var serverPath = _env.ContentRootPath; //Directory.GetCurrentDirectory(); //_env.WebRootPath;
        //                var folerName = @"\wwwroot\Uploads\";
        //                var path = serverPath + folerName; //

        //                System.IO.File.Delete(Path.Combine(path, _countryRepos.GetById(model.Id).Flag));

        //                if (!Directory.Exists(path))
        //                {
        //                    Directory.CreateDirectory(path);
        //                }
        //                string ext = Path.GetExtension(model.Flag.FileName);
        //                string fileName = Path.GetRandomFileName() + ext;

        //                string filePathSave = Path.Combine(path, fileName);

        //                // сохраняем файл в папку Files в каталоге wwwroot
        //                using (var fileStream = new FileStream(filePathSave, FileMode.Create))
        //                {
        //                    await model.Flag.CopyToAsync(fileStream);
        //                }

        //                _countryRepos.Update(
        //                    new Country
        //                    {
        //                        Id = model.Id,
        //                        Name = model.Name,
        //                        Flag = fileName,
        //                        DateModify = DateTime.Now
        //                    });
        //            }

        //            return RedirectToAction("Index");
        //        }
        //        ModelState.AddModelError("", "Дані вказано не коректно");
        //        return View(model);
        //    }

        //    [HttpGet]
        //    public IActionResult Delete(long Id)
        //    {
        //        var country = _countryRepos.GetAll()
        //        .Select(u => new CountryVM
        //        {
        //            Id = u.Id,
        //            Flag = "/Uploads/" + u.Flag,
        //            Name = u.Name
        //        }).FirstOrDefault(c => c.Id == Id);

        //        return View(country);

        //    }

        //    [HttpPost]
        //    public IActionResult Delete(CountryVM model)
        //    {
        //        _countryRepos.Delete(model.Id);
        //        return RedirectToAction("Index");
        //    }
        //}

    }
}
