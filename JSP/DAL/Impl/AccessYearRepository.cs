using DAL.Dtos;
using DAL.EDMX;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Impl
{
    public class AccessYearRepository : BaseImplementation
    {
        public List<AccessYear> GetAll()
        {
            return _context.AccessYears.ToList();
        }
        public ResponseBase Add(AccessYear ay)
        {
            var response = new ResponseBase();
            if (_context.AccessYears.Where(p => p.AY == ay.AY).FirstOrDefault() != null)
            {
                response.ResultSuccess = false;
                response.ResultMessages.Add(new ResultMessage { Message = "AY is already added !" });
                return response;
            }
            _context.AccessYears.Add(ay);
            _context.SaveChanges();
            response.ResultSuccess = true;
            return response;
        }
        public ResponseBase Update(AccessYear ay)
        {
            var response = new ResponseBase();
            try
            {

                var item = _context.AccessYears.Where(p => p.Id == ay.Id).FirstOrDefault();
                item.AY = ay.AY;
                _context.SaveChanges();
                response.ResultSuccess = true;

            }
            catch (System.Exception ex)
            {

                response.ResultMessages.Add(new ResultMessage { Message = "Failed to Update Access Year !" });
                response.ResultSuccess = false;
            }
            return response;
        }
        public ResponseBase Delete(int id)
        {
            var response = new ResponseBase();
            try
            {

                var item = _context.AccessYears.Where(p => p.Id == id).FirstOrDefault();
                _context.AccessYears.Remove(item);
                _context.SaveChanges();
                response.ResultSuccess = true;

            }
            catch (System.Exception ex)
            {

                response.ResultMessages.Add(new ResultMessage { Message = "Failed to Delete Access Year !" });
                response.ResultSuccess = false;
            }
            return response;
        }
    }
}
