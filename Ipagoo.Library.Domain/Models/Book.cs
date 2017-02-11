using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ipagoo.Library.Domain.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author Is Required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Isbn Is Required")]
        public string Isbn { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }
        public string Genre { get; set; }
        public Library Library { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Library")]
        public int LibraryId { get; set; }

        public bool IsOnLoan { get; set; }
    }
}
