using Ipagoo.Library.Domain.Models;
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
    public class LoanCommentRepository : IRepository<LoanComment>, ILoanCommentMarker
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

        public IEnumerable<LoanComment> GetAll()
        {
            return _context.LoanComments.ToArray();
        }

        public LoanComment GetById(int id)
        {
            return _context.LoanComments.SingleOrDefault(p => p.LoanCommentId == id);
        }

        public bool Save(LoanComment objToSave)
        {
            try
            {
                _context.LoanComments.Add(objToSave);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(LoanComment objToUpdate)
        {
            try
            {
                var obj = _context.LoanComments.SingleOrDefault(p => p.LoanCommentId == objToUpdate.LoanCommentId);

                if (obj != null)
                {//nothing to update
                    obj.Comment = objToUpdate.Comment;
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