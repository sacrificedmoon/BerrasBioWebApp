using System;
using System.Collections.Generic;

namespace BerrasBioWebApp.Models
{
    public partial class Salon
    {
        public Salon()
        {
            FilmSchedule = new HashSet<FilmSchedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }

        public virtual ICollection<FilmSchedule> FilmSchedule { get; set; }
    }
}
