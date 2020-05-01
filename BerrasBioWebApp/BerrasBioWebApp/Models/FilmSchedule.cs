using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BerrasBioWebApp
{
    public partial class FilmSchedule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Filmid { get; set; }
        [Required]
        public int Salonid { get; set; }
        [Required]
        public DateTime ShowTime { get; set; }
        [Required]
        public int FreeChairs { get; set; }
        [Required]
        public bool IsFullyBooked { get; set; }
        public virtual Film Film { get; set; }
        public virtual Salon Salon { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
