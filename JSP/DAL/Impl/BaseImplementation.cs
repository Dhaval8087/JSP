using DAL.EDMX;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Impl
{
    public abstract class BaseImplementation
    {
        public JSPEntities _context;
        public BaseImplementation()
        {
            _context = new JSPEntities();
        }
    }
}
