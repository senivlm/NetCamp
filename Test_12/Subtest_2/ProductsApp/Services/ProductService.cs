using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Services
{
    public delegate bool CheckProductDate(Product product);
    internal class ProductService
    {
        public static bool CheckProductDate(Product product)
        {
            Dairy_product dProduct = product as Dairy_product;
            if (dProduct == null) return true;
            if (dProduct.UseBefore > DateTime.Now) return true;
            AddProductToFile(product);
            return false;
        }
        private static void AddProductToFile(Product product, string fileName=Settings.ProductsToRemoveFile)
        {
            try
            {
                FileService.AddStringToFile(fileName, $"{DateTime.Now} {product}\r\n", true);
            }
            catch (Exception ex)
            {
                LoggService.AddLogToFile(ex.Message);
            }
        }
    }
}
