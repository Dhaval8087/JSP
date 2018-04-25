using DAL.EDMX;
using System.Collections.Generic;
using System.Linq;
namespace DAL.Impl
{
    public class ReturnTypeRepository
    {
        private JSPEntities _context;
        public ReturnTypeRepository()
        {
            _context = new JSPEntities();
        }
        public List<ReturnType> GetAll()
        {
            return _context.ReturnTypes.ToList();
        }
    }
}
