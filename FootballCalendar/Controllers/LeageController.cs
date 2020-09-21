using System;
using System.Collections.Generic;
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
    public class LeageController : Controller
    {
        private readonly ILogger<LeageController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public LeageController(ILogger<LeageController> logger,
          ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            var list = _context.Leagues.Select(u => new LeageVM
            {
                Id = u.Id,
                Name = u.Name,
                Country = new CountryVM { Name = u.Country.Name, Flag = "/Uploads/" + u.Country.Flag }
            }).ToList(); ;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new LeageAddVM { Countries = new SelectList(_context.Countries, "Id", "Name") });
        }

        [HttpPost]
        public IActionResult Create(LeageAddVM model)
        {
            if (ModelState.IsValid)
            {


                var leage = _context.Leagues.FirstOrDefault(c => c.Name == model.Name);
                if (leage == null)
                {
                    var result = _context.Leagues.Add
                        (new League
                        {
                            Name = model.Name,
                            CountryId = model.CountryId,
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
