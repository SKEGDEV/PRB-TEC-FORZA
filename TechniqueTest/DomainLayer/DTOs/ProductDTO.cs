using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DTOs
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Name { get; set; }
        [StringLength(300, ErrorMessage = "La descripcion no puede exceder los 300 caracteres")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 99999.99, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Quantity { get; set; }
        [Required]
        public int productTypeId { get; set; }
        public int? productStatusId { get; set; }

    }
}
