using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSP.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InvoiceNumber { get; set; }
        public string Pan { get; set; }
        public string Phone { get; set; }
        public string Path { get; set; }
    }
}
