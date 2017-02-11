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
    public class UserRepository : IRepository<User>,IUserMarker {

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

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToArray();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(p => p.UserId == id);
        }

        public bool Save(User objToSave)
        {
            try
            {
                _context.Users.Add(objToSave);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(User objToUpdate)
        {
            try
            {
                var obj = _context.Users.SingleOrDefault(p => p.UserId == objToUpdate.UserId);

                if (obj != null)
                {
                    obj.FirstName = objToUpdate.FirstName;
                    obj.LastName = objToUpdate.LastName;
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
