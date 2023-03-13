using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Markup;
using System.Text.Json;

namespace QuanLyKhoHang
{
    public class ListProduct
    {
        

        public static List<Product> readFile(string path)
        {
            List<Product> products = new List<Product>();
            try
            {
                var content = System.IO.File.ReadAllText(path);
                JsonDocument doc = JsonDocument.Parse(content);
                JsonElement root = doc.RootElement;
                string json = JsonConvert.SerializeObject(root);

                for (int i = 0; i < root.GetArrayLength(); i++)
                {
                    Product p = new Product();
                    p.ProductID = root[i].GetProperty("ProductID").ToString();
                    p.ProductName = root[i].GetProperty("ProductName").ToString();
                    p.ProductTypeID = root[i].GetProperty("ProductTypeID").ToString();
                    p.Quantity = root[i].GetProperty("Quantity").ToString();
                    p.UnitPrice = root[i].GetProperty("UnitPrice").ToString();
                    
                    products.Add(p);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return products;
        }
        public void writeFile(string path)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }
    }
}
