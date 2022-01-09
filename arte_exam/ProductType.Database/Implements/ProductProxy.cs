using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProductType.Database.Types;
using ProductType.Database.Interfaces;
using Product = ProductType.Database.Models.Product;

namespace ProductType.Database.Implements
{
    public class ProductProxy : IProductProxy
    {
        public Dictionary<int, Product> Products { get; set; }
        public string Version { get; set; } = "0.0.1";
        public string Name { get; set; } = "DB";
        public string Desription { get; set; } = "Desription";

        public ProductProxy()
        {
            Products = new Dictionary<int, Product>();

            using (var databaseContext = new DatabaseContext())
            {
                foreach (Product Product in databaseContext.Products)
                {
                    Products.Add(Product.Id, Product);
                }
            }
        }

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
                    databaseContext.Products.Add(new Product
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

                if (Products.ContainsKey(ProductModel.Id))
                {
                    Products[ProductModel.Id].Name = ProductModel.Name;
                    Products[ProductModel.Id].typeProd = (TypeProd)ProductModel.ProductType;
                }
                else
                {
                    Product = databaseContext.Products.FirstOrDefault(x => x.Name == ProductModel.Name);
                    Products.Add(Product.Id, Product);
                }
            }
        }

        public List<ProductPlugin.Product> Read(int? id)
        {
            using (var context = new DatabaseContext())
            {
                return
                    Products.Values.Where(rec => id == null || rec.Id == id)
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
                Product Product = context.Products.FirstOrDefault(rec => rec.Id == ProductModel.Id);
                if (Product != null)
                {
                    context.Products.Remove(Product);
                    context.SaveChanges();

                    if (Products.ContainsKey(Product.Id))
                        Products.Remove(Product.Id);
                }
                else
                {
                    throw new Exception("not found");
                }
            }
        }
    }
}
