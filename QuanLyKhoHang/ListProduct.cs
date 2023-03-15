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
                var content = File.ReadAllText(path);
                products = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return products;
        }
    }
}
