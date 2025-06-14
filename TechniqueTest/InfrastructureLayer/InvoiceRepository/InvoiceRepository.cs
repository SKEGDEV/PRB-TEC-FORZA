using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.InvoiceRepository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly StoreDbContext _dbContext;
        public InvoiceRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
