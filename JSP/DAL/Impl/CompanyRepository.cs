using DAL.Dtos;
using DAL.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class CompanyRepository : BaseImplementation
    {
        public ResponseBase Add(Company_Details company)
        {
            var response = new ResponseBase();
            try
            {
                if (_context.Company_Details.Where(p => p.Name.ToLower() == company.Name.ToLower() && p.PAN == company.PAN).FirstOrDefault() != null)
                {
                    response.ResultSuccess = false;
                    response.ResultMessages.Add(new ResultMessage { Message = "Company is already added" });
                    return response;
                }
                _context.Company_Details.Add(company);
                _context.SaveChanges();
                response.ResultSuccess = true;

            }
            catch (System.Exception ex)
            {
                Log4Net.WriteException(ex);
                response.ResultMessages.Add(new ResultMessage { Message = "Faild to Add Company" });
            }
            return response;
        }
        public List<Company_Details> Get()
        {
            List<Company_Details> getallCompany = new List<Company_Details>();
            try
            {
                getallCompany = _context.Company_Details.ToList();
            }
            catch (Exception ex)
            {
                Log4Net.WriteException(ex);
            }
            return getallCompany;
        }
    }
}
