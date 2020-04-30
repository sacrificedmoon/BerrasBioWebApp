using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BerrasBioWebApp
{
    public partial class Film
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Title { get; set; }
        [Required] 
        public int Year { get; set; }
        [Required] 
        public TimeSpan Length { get; set; }
        public virtual ICollection<FilmSchedule> FilmSchedules { get; set; }
    }
}
