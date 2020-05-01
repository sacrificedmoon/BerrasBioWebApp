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
        [Display(Name = "Filmtitel")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Längd")]
        public TimeSpan Length { get; set; }
        public virtual ICollection<FilmSchedule> FilmSchedule { get; set; }
    }
}
