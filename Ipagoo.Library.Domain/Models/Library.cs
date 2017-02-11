using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipagoo.Library.Domain.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
