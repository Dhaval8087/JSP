using DAL.EDMX;
using System.Collections.Generic;
using System.Linq;
namespace DAL.Impl
{
    public class ReturnTypeRepository : BaseImplementation
    {
        public List<ReturnType> GetAll()
        {
            return _context.ReturnTypes.ToList();
        }
    }
}
