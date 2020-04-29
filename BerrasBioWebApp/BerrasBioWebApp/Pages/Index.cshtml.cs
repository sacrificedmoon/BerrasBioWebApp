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
        private List<FilmSchedule> AllFS;

        public IndexModel(ILogger<IndexModel> logger, BerrasBioDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IEnumerable<FilmSchedule> FilmSchedule { get; set; }

        public async Task OnGet()
        {
            AllFS = await _db.FilmSchedule.ToListAsync();
            if(AllFS.Count() == 0)
            {
                await SeedFilmSchedule.Initialize(_db);
                AllFS = await _db.FilmSchedule.ToListAsync();
            }

            FilmSchedule = AllFS.Where(fs => fs.ShowTime.Date == DateTime.Today);
            if (FilmSchedule.Count() == 0)
            {
                await SeedFilmSchedule.Initialize(_db);
                AllFS = await _db.FilmSchedule.ToListAsync();
                FilmSchedule = AllFS.Where(fs => fs.ShowTime == DateTime.Today);
            }
        }
    }
}
