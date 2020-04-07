using System;
using System.Collections.Generic;

namespace BerrasBioWebApp.Models
{
    public partial class FilmSchedule
    {
        public int Id { get; set; }
        public int Filmid { get; set; }
        public int Salonid { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Showtime { get; set; }
        public int Freechairs { get; set; }
        public bool Fullybooked { get; set; }

        public virtual Films Film { get; set; }
        public virtual Salons Salon { get; set; }
    }
}
