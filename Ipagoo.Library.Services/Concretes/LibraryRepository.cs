using Ipagoo.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ipagoo.Library.Domain.Models;
using Ipagoo.Library.DataAccess;

namespace Ipagoo.Library.Services.Concretes
{
    public class LibraryRepository : IRepository<Domain.Models.Library>, IMarkers.ILibraryMarker
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

    public IEnumerable<Book> GetAll()
    {
        return _context.Books.ToArray();
    }

    public Domain.Models.Library GetById(int id)
    {
        return _context.Libraries.SingleOrDefault(p => p.LibraryId == id);
    }

    public bool Save(Domain.Models.Library objToSave)
    {
        try
        {
            _context.Libraries.Add(objToSave);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(Domain.Models.Library objToUpdate)
    {
        try
        {
            var obj = _context.Libraries.SingleOrDefault(p => p.LibraryId == objToUpdate.LibraryId);

            if (obj != null)
            {
               //No need to update library
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

        Domain.Models.Library IRepository<Domain.Models.Library>.GetById(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Domain.Models.Library> IRepository<Domain.Models.Library>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
