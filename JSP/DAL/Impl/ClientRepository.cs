using DAL.Dtos;
using DAL.EDMX;
using System;
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
        public ClientsWithCount GetAll(int id, int offset, bool isCount = false)
        {
            ClientsWithCount response = new ClientsWithCount();
            try
            {

                response.Clients = _context.Clients.Where(p => p.ReturnTypeId == id).OrderBy(p => p.Id).Skip(offset).Take(10).ToList();
                if (isCount)
                    response.TotalCount = _context.Clients.Count(p => p.ReturnTypeId == id);
            }
            catch (System.Exception ex)
            {
                Log4Net.WriteException(ex);
                return null;
            }
            return response;
        }
        public ClientsWithCount GetByFilter(int id, string columnName, string value, int offset, bool isCount = false)
        {
            ClientsWithCount response = new ClientsWithCount();
            try
            {
                switch (columnName)
                {
                    case "Name":
                        response.Clients = _context.Clients.Where(p => p.Name.Contains(value) && p.ReturnTypeId == id).OrderBy(p => p.Id).Skip(offset).Take(10).ToList();
                        if (isCount)
                            response.TotalCount = _context.Clients.Where(p => p.Name.Contains(value) && p.ReturnTypeId == id).Count();
                        break;
                    case "PanCard":
                        response.Clients = _context.Clients.Where(p => p.PAN.Contains(value) && p.ReturnTypeId == id).OrderBy(p => p.Id).Skip(offset).Take(10).ToList();
                        if (isCount)
                            response.TotalCount = _context.Clients.Where(p => p.PAN.Contains(value) && p.ReturnTypeId == id).Count();
                        break;
                    default:
                        break;
                }

            }
            catch (System.Exception ex)
            {

                Log4Net.WriteException(ex);
            }
            return response;
        }
        public ResponseBase AddClientDetails(Client_Details details,string filePath)
        {
            var response = new ResponseBase();
            try
            {
                var findClientDetails = _context.Client_Details.Where(p => p.AY == details.AY && p.ClientId == details.ClientId).FirstOrDefault();
                if (findClientDetails != null)
                {
                    details.Id = findClientDetails.Id;
                    //response.ResultSuccess = false;
                    //response.ResultMessages.Add(new ResultMessage { Message = "Invoice already generated" });
                    //return response;
                }
                else
                {
                    _context.Client_Details.Add(details);
                    _context.SaveChanges();
                }

                var lastIds = _context.Client_Invoice.Where(p => p.Client_Id == details.ClientId).OrderByDescending(p => p.Id).FirstOrDefault();
                Client_Invoice invoice = new Client_Invoice();

                invoice.Client_DetailsId = details.Id;
                invoice.Client_Id = details.ClientId;
                invoice.Path = filePath;
                string number = "1";
                if (lastIds != null)
                {
                    number = (Convert.ToInt32(lastIds.InvoiceNumber.Substring(lastIds.InvoiceNumber.IndexOf(" "), lastIds.InvoiceNumber.Length - lastIds.InvoiceNumber.IndexOf(" ")).Trim()) + 1).ToString();
                }
                invoice.InvoiceNumber = "Invoice " + number;


                _context.Client_Invoice.Add(invoice);
                _context.SaveChanges();
                response.ResultSuccess = true;

            }
            catch (System.Exception ex)
            {
                Log4Net.WriteException(ex);
                response.ResultMessages.Add(new ResultMessage { Message = "Faild to Generate Invoice" });
            }
            return response;
        }
    }
}
