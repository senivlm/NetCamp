using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Model
{
    internal class Stock:ICloneable
    {
        List<StockProduct> products;
        public Stock()
        {
            products = new List<StockProduct>();
        }
        public Stock(List<StockProduct> newProducts)
        {
            products = newProducts.ToList();
        }
        public void AddProduct(StockProduct stockProduct)
        {
            if (products.Contains(stockProduct))
            {
                StockProduct product = products.Find(prod => prod.Equals(stockProduct));
                product.Count += stockProduct.Count;
            }
            else
            {
                products.Add(new StockProduct
                {
                    Name = stockProduct.Name,
                    Count = stockProduct.Count,
                    Price = stockProduct.Price,
                    Weight = stockProduct.Weight,
                });
            }
        }
        public void AddProduct(List<StockProduct> products)
        {
            foreach (StockProduct product in products)
            {
                AddProduct(product);
            }
        }
        public static List<StockProduct> operator +(Stock a, Stock b)
        {
            List<StockProduct> productsA = a.products.ToList();
            List<StockProduct> productsB = b.products.ToList();
            foreach (StockProduct productB in productsB)
            {
                if (productsA.Contains(productB))
                {
                    StockProduct productA = productsA.Find(prod => prod.Equals(productB));
                    productA.Count += productB.Count;
                }
                else
                {
                    productsA.Add(productB);
                }
            }
            return productsA.ToList();
        }
        public static List<StockProduct> operator -(Stock a, Stock b)
        {
            List<StockProduct> productsA = a.products.ToList();
            List<StockProduct> productsB = b.products.ToList();
            foreach (StockProduct productB in productsB)
            {
                if (productsA.Contains(productB))
                {
                    StockProduct productA = productsA.Find(prod => prod.Equals(productB));
                    if (productA.Count > productB.Count)
                    {
                        productA.Count -= productB.Count;
                    }
                    else
                    {
                        productsA.Remove(productA);
                    }
                }
            }
            return productsA.ToList();
        }
        public List<StockProduct> Joint(Stock b)
        {
            List<StockProduct> productsA = products.ToList();
            List<StockProduct> productsB = b.products.ToList();
            foreach (StockProduct productB in productsB)
            {
                if (productsA.Contains(productB))
                {
                    StockProduct productA = productsA.Find(prod => prod.Equals(productB));
                    productA.Count = Math.Min(productA.Count, productB.Count);
                }
                else
                {
                    productsA.Add(productB);
                }
            }
            return productsA.ToList();
        }

        public object Clone()
        {
            return new Stock(products);
        }
    }
}
