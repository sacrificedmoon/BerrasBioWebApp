using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
        public InputModel Input { get; set; }
        [BindProperty]
        public FilmSchedule FilmSchedule { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Antal biljetter")]
            public int NumOfTickets { get; set; }

            [Required]
            [Display(Name = "Namn")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Telefonnummer")]
            [Range(10000000, 799999999, ErrorMessage = "The {0} must only contain numbers and be 9-10 digits long")]
            [StringLength(10,ErrorMessage = "The {0} must only contain numbers and be {2}-{1} digits long", MinimumLength=9)]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAsync(int id)
        {
            FilmSchedule = await _db.FilmSchedule
                .Include(fs => fs.Film)
                .Include(fs => fs.Salon)
                .FirstOrDefaultAsync(fs => fs.Id == id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("AddBooking", FilmSchedule);
            }

            if (Input.NumOfTickets > 12)
            {
                return RedirectToPage("AddBooking", FilmSchedule);
            }

            FilmSchedule filmschedule = await _db.FilmSchedule.FindAsync(FilmSchedule.Id);
            filmschedule.FreeChairs -= Input.NumOfTickets;

            Booking booking = new Booking
            {
                FilmScheduleId = this.FilmSchedule.Id,
                Name = Input.Name,
                PhoneNumber = Input.PhoneNumber,
                NumOfTickets = Input.NumOfTickets
            };

            _db.Booking.Add(booking);
            await _db.SaveChangesAsync();

            return RedirectToPage("BookingConfirmation", booking);
        }
    }
}
