using System;
using System.Collections.Generic;
using System.Text;
using ProductType;
using ProductType.Database.Interfaces;
using ProductType.Database.Models;
using ProductType.Database.Types;
using System.Linq;

namespace ProductType.Database.Implements
{
    public class ProductImplement : IProductProxy
    {
        public string Version { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Desription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CreateOrUpdate(ProductPlugin.Product ProductModel)
        {
            using (var databaseContext = new DatabaseContext())
            {
                var Product = databaseContext.Products.FirstOrDefault(x => x.Id != ProductModel.Id
                && x.Name == ProductModel.Name);

                if (Product != null)
                {
                    throw new Exception("already exists");
                }

                Product = databaseContext.Products.FirstOrDefault(x => x.Id == ProductModel.Id);

                if (Product == null)
                {
                    databaseContext.Products.Add(new Models.Product
                    {
                        Name = ProductModel.Name,
                        typeProd = (TypeProd)ProductModel.ProductType
                    });
                }
                else
                {
                    Product.Name = ProductModel.Name;
                    Product.typeProd = (TypeProd)ProductModel.ProductType;
                }


                databaseContext.SaveChanges();
            }
        }

        public List<ProductPlugin.Product> Read(int? id)
        {
            using (var context = new DatabaseContext())
            {
                return
                    context.Products.Where(rec => id == null || rec.Id == id)
                    .Select(x => new ProductPlugin.Product
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ProductType = (int)x.typeProd
                    }).ToList();
            }
        }

        public void RemoveProduct(ProductPlugin.Product ProductModel)
        {
            using (var context = new DatabaseContext())
            {
                Models.Product Product = context.Products.FirstOrDefault(rec => rec.Id == ProductModel.Id);
                if (Product != null)
                {
                    context.Products.Remove(Product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("not found");
                }
            }
        }
    }
}
