
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musical.Web.Models
{
    public class Genre {

        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name="Genero")]
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }

    }

}