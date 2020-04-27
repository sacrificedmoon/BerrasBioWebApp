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
        public IndexModel(ILogger<IndexModel> logger, BerrasBioDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IEnumerable<FilmSchedule> FilmSchedule { get; set; }

        public async Task OnGet()
        {
            var AllFS = await _db.FilmSchedule.ToListAsync();
            FilmSchedule = AllFS.Where(fs => fs.Date == DateTime.Today);

            if (FilmSchedule == null) AddTodayMovies();
        }

        private void AddTodayMovies()
        {
            //new FilmSchedule
            //{

            //};
        }
    }
}
