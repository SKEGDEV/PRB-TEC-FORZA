using InfrastructureLayer.InvoiceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InvoiceLogic
{
    public class InvoiceOrchestLogic
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceHelperLogic _invoiceHelperLogic;
        public InvoiceOrchestLogic(IInvoiceRepository invoiceRepository, InvoiceHelperLogic invoiceHelperLogic)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceHelperLogic = invoiceHelperLogic;
        }
    }
}
