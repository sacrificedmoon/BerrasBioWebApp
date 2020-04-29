using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBioWebApp
{
    public class SeedFilmSchedule
    {
        public static async Task<int> Initialize(BerrasBioDbContext db)
        {
            db.FilmSchedule.AddRange(
                new FilmSchedule
                {
                    Filmid = 1,
                    Salonid = 1,
                    ShowTime = DateTime.Today.AddHours(16),
                    FreeChairs = db.Salon.First(s => s.Id == 1).Seats,
                    IsFullyBooked = false
                },

                new FilmSchedule
                {
                    Filmid = 2,
                    Salonid = 2,
                    ShowTime = DateTime.Today.AddHours(16),
                    FreeChairs = db.Salon.First(s => s.Id == 2).Seats,
                    IsFullyBooked = false
                },

                new FilmSchedule
                {
                    Filmid = 3,
                    Salonid = 1,
                    ShowTime = DateTime.Today.AddHours(18).AddMinutes(30),
                    FreeChairs = db.Salon.First(s => s.Id == 1).Seats,
                    IsFullyBooked = false
                },

                new FilmSchedule
                {
                    Filmid = 4,
                    Salonid = 2,
                    ShowTime = DateTime.Today.AddHours(18).AddMinutes(30),
                    FreeChairs = db.Salon.First(s => s.Id == 2).Seats,
                    IsFullyBooked = false
                },


                new FilmSchedule
                {
                    Filmid = 5,
                    Salonid = 1,
                    ShowTime = DateTime.Today.AddHours(21),
                    FreeChairs = db.Salon.First(s => s.Id == 1).Seats,
                    IsFullyBooked = false
                },

                new FilmSchedule
                {
                    Filmid = 6,
                    Salonid = 2,
                    ShowTime = DateTime.Today.AddHours(21),
                    FreeChairs = db.Salon.First(s => s.Id == 2).Seats,
                    IsFullyBooked = false
                }
            );
            return await db.SaveChangesAsync();
        }
    }
}
