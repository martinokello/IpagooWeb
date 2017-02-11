using Ipagoo.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ipagoo.Library.Domain.Models;
using Ipagoo.Library.DataAccess;
using Ipagoo.Library.Services.IMarkers;

namespace Ipagoo.Library.Services.Concretes
{
    public class LoanRepository : IRepository<Loan> ,ILoanMarker
    {
    
        public IpagooDbContext Context
        {
            get
            {
                return _context;
            }

            set
            {
                _context = value;
            }
        }

        DataAccess.IpagooDbContext _context;

        public IEnumerable<Loan> GetAll()
        {
            return _context.Loans.ToArray();
        }

        public Loan GetById(int id)
        {
            return _context.Loans.SingleOrDefault(p => p.LoanId == id);
        }

        public bool Save(Loan objToSave)
        {
            try
            {
                _context.Loans.Add(objToSave);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Loan objToUpdate)
        {
            try
            {
                var obj = _context.Loans.SingleOrDefault(p => p.LoanId == objToUpdate.LoanId);

                if (obj != null)
                {//nothing to update
                    obj.DateLoaned = objToUpdate.DateLoaned;
                    obj.DateReturned = objToUpdate.DateReturned;
                    obj.UserId = objToUpdate.UserId;

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}