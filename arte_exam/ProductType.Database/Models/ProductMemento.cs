using ProductType.Database.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductType.Database.Models
{
    public class ProductMemento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeProd typeProd { get; set; }
    }
}
