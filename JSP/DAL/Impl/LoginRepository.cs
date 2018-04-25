using System;
using System.Linq;

namespace DAL.Impl
{
    public class LoginRepository : BaseImplementation
    {

        public LoginRepository()
        {
        }
        public bool AutheticateUser(string username, string password)
        {
            bool isValid = false;
            try
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
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
