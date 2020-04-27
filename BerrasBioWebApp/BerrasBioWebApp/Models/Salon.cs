using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BerrasBioWebApp
{
    public partial class Salon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Seats { get; set; }

        public ICollection<FilmSchedule> FilmSchedule { get; set; }
    }
}
