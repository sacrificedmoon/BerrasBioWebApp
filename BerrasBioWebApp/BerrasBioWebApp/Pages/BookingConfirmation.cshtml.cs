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
        private readonly BerrasBioDbContext _db;

        public BookingConfirmationModel(BerrasBioDbContext db)
        {
            _db = db;
        }

        public Booking Booking { get; set; }

        public async Task OnGetAsync(Booking booking)
        {
            Booking = await _db.Booking
                .Include(b  =>  b.FilmSchedule)
                .Include(b  =>  b.FilmSchedule.Film)
                .Include(b  =>  b.FilmSchedule.Salon)
                .FirstAsync(b  =>  b.Id == booking.Id);
        }
    }
}
