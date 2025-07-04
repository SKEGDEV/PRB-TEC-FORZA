﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityStock { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductStatusId { get; set; }

        public ProductType? ProductType { get; set; }
        public ProductStatus? ProductStatus { get; set; }
    }
}
