using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using ComplaintApp.API.Model;

namespace ComplaintApp.API.Repository
{
   public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(bool includeRemoved = false);
        int Insert(T entity);
       
    }
}
