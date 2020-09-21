using FootballСalendar.Entities;
using FootballСalendar.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Repo.Implement
{
    public class CityRepo : BaseRepository<City, long>, ICityRepo
    {
        public CityRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}
