using DAL.EDMX;

namespace DAL.Impl
{
    public class ClientRepository : BaseImplementation
    {
        public int AddClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return 1;

            }
            catch (System.Exception ex)
            {
                Log4Net.WriteException(ex);
                return 0;
            }

        }
    }
}
