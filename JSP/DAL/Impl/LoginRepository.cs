using DAL.Dtos;
using DAL.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class LoginRepository
    {
        private JSPEntities _context;
        public LoginRepository()
        {
            _context = new JSPEntities();
        }
       public bool AutheticateUser(string username,string password)
        {
            bool isValid = false;
            try
            {
                if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    return _context.Logins.Any(p => p.Username.ToLower() == username.ToLower() && p.Password == password);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log4Net.WriteException(ex);
            }
            return isValid;
        }
    }
}
