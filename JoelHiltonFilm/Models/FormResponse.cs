using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilm.Models
{
    public class FormResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
