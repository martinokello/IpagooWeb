using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipagoo.Library.Services.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();

        bool Save(T objToSave);

        bool Update(T objtoUpdate);
    
        DataAccess.IpagooDbContext Context { get; set; }
    }
}
