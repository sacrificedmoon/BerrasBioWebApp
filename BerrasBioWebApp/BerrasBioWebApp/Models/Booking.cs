
using System.ComponentModel.DataAnnotations;

namespace BerrasBioWebApp
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public int FilmScheduleId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public int PhoneNumber { get; set; }

        public FilmSchedule FilmSchedule { get; set; }
    }
}
