using DAL.Dtos;
using DAL.EDMX;
using System.Collections.Generic;
using System.Linq;
namespace DAL.Impl
{
    public class ClientRepository : BaseImplementation
    {
        public ResponseBase Add(Client client)
        {
            var response = new ResponseBase();
            try
            {
                if (_context.Clients.Where(p => p.Name.ToLower() == client.Name.ToLower() && p.PAN == client.PAN && p.DOB == client.DOB).FirstOrDefault() != null)
                {
                    response.ResultSuccess = false;
                    response.ResultMessages.Add(new ResultMessage { Message = "Client is already added" });
                    return response;
                }
                _context.Clients.Add(client);
                _context.SaveChanges();
                response.ResultSuccess = true;

            }
            catch (System.Exception ex)
            {
                Log4Net.WriteException(ex);
                response.ResultMessages.Add(new ResultMessage { Message = "Faild to Add Client" });
            }
            return response;
        }
        public List<Client> GetAll(int id)
        {
            try
            {
                return _context.Clients.Where(p => p.ReturnTypeId == id).ToList();
            }
            catch (System.Exception ex)
            {
                Log4Net.WriteException(ex);
                return null;
            }
        }
    }
}
