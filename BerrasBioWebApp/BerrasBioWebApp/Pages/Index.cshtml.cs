using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BerrasBioWebApp.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IEnumerable Films { get; set; }
        public async Task OnGet()
        {
            Films = await _db.Films.ToListAsync();
        }
    }
}
