using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ipagoo.Library.Domain.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [ForeignKey("User")]
        [Required(ErrorMessage = "UserId Is Required")]
        public int UserId { get; set; }
        public IEnumerable<Book> Books{ get; set; }
        public User User { get; set; }
        public DateTime DateLoaned { get; set; }
        public DateTime DateReturned { get; set; }
    }
}
