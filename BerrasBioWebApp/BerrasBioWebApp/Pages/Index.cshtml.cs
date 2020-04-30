using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace BerrasBioWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BerrasBioDbContext _db;
        private List<FilmSchedule> AllFilmSchedules;

        public IndexModel(ILogger<IndexModel> logger, BerrasBioDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IEnumerable<FilmSchedule> FilmSchedulesToday { get; set; }


        public async Task OnGet()
        {
            _db.
            await _db.Film.ToListAsync();
            await _db.Salon.ToListAsync();
            AllFilmSchedules = await _db.FilmSchedule.ToListAsync();
            if(AllFilmSchedules.Count() == 0)
            {
                await SeedDatabase.SeedDatabaseFirstTime(_db);
                AllFilmSchedules = await _db.FilmSchedule.ToListAsync();
            }

            FilmSchedulesToday = AllFilmSchedules.Where(fs => fs.ShowTime.Date == DateTime.Today);
            if (FilmSchedulesToday.Count() == 0)
            {
                await SeedDatabase.SeedMovieScheduleToday(_db);
                AllFilmSchedules = await _db.FilmSchedule.ToListAsync();
                FilmSchedulesToday = AllFilmSchedules.Where(fs => fs.ShowTime == DateTime.Today);
            }
        }
    }
}
