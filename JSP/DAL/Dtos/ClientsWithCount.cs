using DAL.EDMX;
using System.Collections.Generic;

namespace DAL.Dtos
{
    public class ClientsWithCount
    {
        public List<Client> Clients { get; set; }
        public int TotalCount { get; set; }
    }
}
