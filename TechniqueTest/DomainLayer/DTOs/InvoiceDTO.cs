using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DTOs
{
    public class InvoiceDTO
    {
        public string? clientFullName {  get; set; }
        public string? clientDirection { get; set; }
        public string? clientDocumentNumber {  get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "La peticion debe contener por lo menos un producto")]
        public List<InvoiceProductDTO> products { get; set; }
    }
}
