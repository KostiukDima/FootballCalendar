
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Models
{
    public class HomeTeamVM
    {
        public int GoalCount { get; set; }
        public FootballClubVM FootballClubVM { get; set; }
    }

    public class OpponentTeamVM
    {
        public int GoalCount { get; set; }
        public FootballClubVM FootballClubVM { get; set; }
    }

    public class HomeTeamAddVM
    {
        public long? FootballClubId { get; set; }
        public SelectList FootballClubs;
    }

    public class OpponentTeamAddVM
    {
        public long? FootballClubId { get; set; }
        public SelectList FootballClubs;
    }

    public class FootballGameVM
    {
        public long Id { get; set; }
        public HomeTeamVM HomeTeamVM { get; set; }
        public OpponentTeamVM OpponentTeamVM { get; set; }               
        public StadiumVM StadiumVM { get; set; }
        public DateTime DateTime { get; set; }
        public LeageVM LeagueVM { get; set; }
    }

    public class FootballGameAddVM
    {
    //    public HomeTeamAddVM HomeTeamAddVM { get; set; }
    //    public OpponentTeamAddVM OpponentTeamAddVM { get; set; }
        public DateTime DateTime { get; set; }
        public int HomeTeamId { get; set; }
        public int OpponentTeamId { get; set; }
        public SelectList FootballClubs { get; set; }
        public int StadiumId { get; set; }
        public SelectList Stadiums;

        public int LeagueId { get; set; }
        public SelectList Leagues { get; set; }
    }

}
