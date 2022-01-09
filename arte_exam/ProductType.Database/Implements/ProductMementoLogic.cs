using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProductType.Database.Interfaces;
using ProductType.Database.Models;
using ProductType.Database.Types;

namespace ProductType.Database.Implements
{
    public class ProductMementoLogic : IMemento
    {
        public Queue<List<ProductMemento>> ProductsHistory;
        public ProductMementoLogic()
        {
            ProductsHistory = new Queue<List<Models.ProductMemento>>();
        }
        public void Undo()
        {
            if (ProductsHistory.Count < 1)
            {
                return;
            }
            var Products = ProductsHistory.Dequeue();

            using (var context = new DatabaseContext())
            {
                foreach (var Product in Products)
                {
                    var u = context.Products.FirstOrDefault(x => x.Id == Product.Id);

                    if (u != null)
                    {
                        u.Name = Product.Name;
                        u.typeProd = Product.typeProd;
                    }
                }
            }
        }

        public void Save(List<Product> Products)
        {
            ProductsHistory.Enqueue(Products.Select(x => new ProductMemento
            {
                Id = x.Id,
                Name = x.Name,
                typeProd = x.typeProd
            }).ToList());
        }
    }
}
