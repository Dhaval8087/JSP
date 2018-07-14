using DAL.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class ClientInvoiceRespository : BaseImplementation
    {
        public List<Client_Invoice> GetInvoices(string ay)
        {
            var response = new List<Client_Invoice>();
            try
            {
                var clntDetails = _context.Client_Details.Where(p => p.AY == ay).FirstOrDefault();
                if (clntDetails != null)
                {
                    response = _context.Client_Invoice.Include("Client_Details").Where(p => p.Client_DetailsId == clntDetails.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                Log4Net.WriteException(ex);
            }
            return response;
        }
    }
}
