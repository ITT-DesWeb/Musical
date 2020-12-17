using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musical.Web.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string ApplicationUser { get; set; }
        [Display(Name="Artista")]
        [ForeignKey("ApplicationUser")]
        public ApplicationUser Artist { get; set; }
      
        [Display(Name ="Fecha del Evento")]
        public DateTime DateTime { get; set; }
        [Display(Name ="Lugar")]
        public string Place { get; set; }
        public string Picture { get; set; }
        [Display(Name ="Genero")]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        [Display(Name ="Genero")]
        public Genre Genre { get; set; }

        
    }

}