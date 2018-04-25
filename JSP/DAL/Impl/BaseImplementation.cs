using DAL.EDMX;

namespace DAL.Impl
{
    public class BaseImplementation
    {
        public JSPEntities _context;
        public BaseImplementation()
        {
            _context = new JSPEntities();
        }
    }
}
