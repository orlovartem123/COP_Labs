using System;
using System.Collections.Generic;
using System.Text;
using ProductType.Database.Models;

namespace ProductType.Database.Interfaces
{
    public interface IMemento
    {
        void Save(List<Product> Products);
        void Undo();
    }
}
