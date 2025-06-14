using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string clientFullName { get; set; }
        public string clientDirection { get; set; }
        public string clientDocumentNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Total { get; set; }
    }
}
