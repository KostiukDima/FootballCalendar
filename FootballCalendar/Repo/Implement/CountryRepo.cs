using FootballСalendar.Entities;
using FootballСalendar.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Repo.Implement
{

    public class CountryRepo : BaseRepository<Country, long>, ICountryRepo
    {
        public CountryRepo(ApplicationDbContext context) : base(context)
        {

        }
    }
}
