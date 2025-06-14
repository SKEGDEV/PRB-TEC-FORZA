using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DTOs
{
    public class InvoiceProductDTO
    {
        [Required]
        public int invoiceId { get; set; }
        [Required]
        public int productId { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01, 99999.99, ErrorMessage = "El precio unitario debe ser mayor a 0.")]
        public decimal unitPrice { get; set; }
    }
}
