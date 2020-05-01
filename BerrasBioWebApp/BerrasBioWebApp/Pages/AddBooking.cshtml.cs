using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BerrasBioWebApp;

namespace BerrasBioWebApp.Pages
{
    public class AddBookingModel : PageModel
    {
        private readonly BerrasBioDbContext _db;

        public AddBookingModel(BerrasBioDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public FilmSchedule FilmSchedule { get; set; }

        public async Task OnGetAsync(int id)
        {
            FilmSchedule = await _db.FilmSchedule.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Booking.Add(Booking);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
