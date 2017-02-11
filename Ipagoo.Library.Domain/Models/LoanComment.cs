using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ipagoo.Library.Domain.Models
{
    public class LoanComment
    {
        [Key]
        public int LoanCommentId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Loan")]
        public int LoanId { get; set; }
        public Book Book { get; set; }
        public Book Loan { get; set; }
        public string Comment { get; set; }
    }
}
