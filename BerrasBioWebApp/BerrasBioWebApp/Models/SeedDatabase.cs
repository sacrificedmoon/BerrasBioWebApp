using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBioWebApp
{
    public class SeedDatabase
    {
        public static async Task SeedMovieScheduleToday(BerrasBioDbContext db)
        {
            db.FilmSchedule.AddRange(
                new FilmSchedule
                {
                    Filmid = 1,
                    Salonid = 1,
                    ShowTime = DateTime.Today.AddHours(16),
                    FreeChairs = 50,
                    IsFullyBooked = false
                },

                new FilmSchedule
                {
                    Filmid = 2,
                    Salonid = 2,
                    ShowTime = DateTime.Today.AddHours(16),
                    FreeChairs = 100,
                    IsFullyBooked = false
                },

                new FilmSchedule
                {
                    Filmid = 3,
                    Salonid = 1,
                    ShowTime = DateTime.Today.AddHours(18).AddMinutes(30),
                    FreeChairs = 50,
                    IsFullyBooked = false
                },

                new FilmSchedule
                {
                    Filmid = 4,
                    Salonid = 2,
                    ShowTime = DateTime.Today.AddHours(18).AddMinutes(30),
                    FreeChairs = 100,
                    IsFullyBooked = false
                },


                new FilmSchedule
                {
                    Filmid = 5,
                    Salonid = 1,
                    ShowTime = DateTime.Today.AddHours(21),
                    FreeChairs = 50,
                    IsFullyBooked = false
                },

                new FilmSchedule
                {
                    Filmid = 6,
                    Salonid = 2,
                    ShowTime = DateTime.Today.AddHours(21),
                    FreeChairs = 100,
                    IsFullyBooked = false
                }
            );
            await db.SaveChangesAsync();
        }

        public static async Task SeedDatabaseFirstTime(BerrasBioDbContext db)
        {
            db.Film.AddRange(
                new Film
                {
                    Title = "Casino Royale (Barry Nelson)",
                    Length = TimeSpan.FromMinutes(60)
                },
                new Film
                {
                    Title = "Goldenfinger (Sean Connery)",
                    Length = TimeSpan.FromMinutes(110)
                },
                new Film
                {
                    Title = "Live and Let Die (Roger Moore)",
                    Length = TimeSpan.FromMinutes(120)
                },
                new Film
                {
                    Title = "Octopussy (Roger Moore)",
                    Length = TimeSpan.FromMinutes(130)
                },
                new Film
                {
                    Title = "Tomorrow Never Dies (Pierce Brosnan)",
                    Length = TimeSpan.FromMinutes(120)
                },
                new Film
                {
                    Title = "Quantum of Solace (Daniel Craig)",
                    Length = TimeSpan.FromMinutes(110)
                }
            );

            db.Salon.AddRange(
                new Salon
                {
                    Name = "Saga",
                    Seats = 50
                },
                new Salon
                {
                    Name = "La Scala",
                    Seats = 100
                }
            );

            await db.SaveChangesAsync();
            await SeedMovieScheduleToday(db);
        }

    }
}
