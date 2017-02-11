using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipagoo.Library.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "FirstName Is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Is Required")]
        public string LastName { get; set; }
        public IEnumerable<Loan> Loans { get; set; }
    }
}
