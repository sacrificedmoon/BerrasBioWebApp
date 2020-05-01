using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BerrasBioWebApp;

namespace BerrasBioWebApp.Pages
{
    public class BookingConfirmationModel : PageModel
    {
        private readonly BerrasBioWebApp.BerrasBioDbContext _context;

        public BookingConfirmationModel(BerrasBioWebApp.BerrasBioDbContext context)
        {
            _context = context;
        }

        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking
                .Include(b => b.FilmSchedule)
                .Include(b => b.FilmSchedule.Film)
                .Include(b => b.FilmSchedule.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
