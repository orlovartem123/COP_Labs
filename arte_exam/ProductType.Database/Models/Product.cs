using System;
using System.Collections.Generic;
using System.Text;
using ProductType.Database.Types;

namespace ProductType.Database.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeProd typeProd { get; set; }
    }
}
