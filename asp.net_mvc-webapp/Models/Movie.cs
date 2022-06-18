using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_webapp.Models
{
    public class Movie
    {
        //auto increasement(automatic, not set)
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        //format datetime: 1/1/2542 0:00:00
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }
    }
}