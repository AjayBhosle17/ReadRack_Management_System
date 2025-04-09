using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_UI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString ="{0:dd/mm/yyyy}")]
        public DateTime PublishedDate { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string BookCoverPhoto { get; set; }
    }
}