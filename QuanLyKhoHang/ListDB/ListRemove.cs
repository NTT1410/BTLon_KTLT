using Newtonsoft.Json;
using QuanLyKhoHang.Instance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.ListDB
{
    public class ListRemove
    {
        public static List<RemoveProduct> readFile(string path)
        {
            List<RemoveProduct> removeproducts = new List<RemoveProduct>();
            try
            {
                var content = File.ReadAllText(path);
                removeproducts = JsonConvert.DeserializeObject<List<RemoveProduct>>(content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return removeproducts;
        }
    }
}
