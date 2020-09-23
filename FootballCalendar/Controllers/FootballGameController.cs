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
    public class FootballGameController : Controller
    {

        private readonly ILogger<FootballGameController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FootballGameController(ILogger<FootballGameController> logger,
          ApplicationDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            var list = _context.FootballGames.Select(u => new FootballGameVM
            {
                Id = u.Id,
                LeagueVM = new LeageVM { Name = u.League.Name },
                StadiumVM = new StadiumVM { Name = u.Stadium.Name },
                DateTime = u.DateTime,
                HomeTeamVM = new HomeTeamVM
                {
                    GoalCount = u.HomeTeam.GoalCount,
                    FootballClubVM = new FootballClubVM
                    {
                        Id = u.HomeTeam.FootballClub.Id,
                        Logo = "/Uploads/" + u.HomeTeam.FootballClub.Logo,
                        Name = u.HomeTeam.FootballClub.Name
                    }
                },
                OpponentTeamVM = new OpponentTeamVM
                {
                    GoalCount = u.OpponentTeam.GoalCount,
                    FootballClubVM = new FootballClubVM
                    {
                        Id = u.OpponentTeam.FootballClub.Id,
                        Logo = "/Uploads/" + u.OpponentTeam.FootballClub.Logo,
                        Name = u.OpponentTeam.FootballClub.Name
                    }
                },


            }).ToList(); ;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new FootballGameAddVM
            {

                FootballClubs = new SelectList(_context.FootballClubs, "Id", "Name"),
                Stadiums = new SelectList(_context.Stadiums, "Id", "Name"),
                Leagues = new SelectList(_context.Leagues, "Id", "Name")

            });
        }

        [HttpPost]
        public IActionResult Create(FootballGameAddVM model)
        {
            if (ModelState.IsValid)
            {
                var result = _context.FootballGames.Add
                    (new FootballGame
                    {
                        HomeTeam = new HomeTeam
                        {
                            FootballClubId = model.HomeTeamId,
                            GoalCount = 0
                        },
                        OpponentTeam = new OpponentTeam
                        {
                            FootballClubId = model.OpponentTeamId,
                            GoalCount = 0
                        },
                        GameStatusId = 1,
                        StadiumId = model.StadiumId,
                        LeagueId = model.LeagueId,
                        DateCreate = DateTime.Now,
                        DateTime = model.DateTime
                       
                    });
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Дані вказано не коректно");
            return View(model);
        }
    }
}
