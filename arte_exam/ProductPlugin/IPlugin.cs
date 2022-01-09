using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlugin
{
    public interface IPlugin
    {
        string Version { get; set; }
        string Name { get; set; }
        string Desription { get; set; }
        void CreateOrUpdate(Product product);
        void RemoveProduct(Product product);
        List<Product> Read(int? id);
    }
}
