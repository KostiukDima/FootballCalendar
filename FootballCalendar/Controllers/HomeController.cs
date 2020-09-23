using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FootballСalendar.Models;
using FootballСalendar.Entities;
using Microsoft.AspNetCore.Hosting;

namespace FootballСalendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger,
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
