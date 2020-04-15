using System;
using System.Collections.Generic;

namespace BerrasBioWebApp.Models
{
    public partial class Film
    {
        public Film()
        {
            FilmSchedule = new HashSet<FilmSchedule>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public TimeSpan Length { get; set; }

        public virtual ICollection<FilmSchedule> FilmSchedule { get; set; }
    }
}
