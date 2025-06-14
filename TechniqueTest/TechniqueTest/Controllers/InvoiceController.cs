using Microsoft.AspNetCore.Mvc;
using DomainLayer.DTOs;
using ApplicationLayer.InvoiceLogic;

namespace TechniqueTest.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly InvoiceOrchestLogic _invoiceOrchestLogic;
        public InvoiceController(InvoiceOrchestLogic invoiceOrchestLogic)
        {
            _invoiceOrchestLogic = invoiceOrchestLogic;
        }

        
    }
}
