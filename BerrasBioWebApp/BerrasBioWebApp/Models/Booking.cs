
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
        [Display(Name= "Namn")]
        public string Name { get; set; }
        [Required]
        [Display(Name= "Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name= "Antal biljetter")]
        public int NumOfTickets { get; set; }
        public virtual FilmSchedule FilmSchedule { get; set; }
    }
}
