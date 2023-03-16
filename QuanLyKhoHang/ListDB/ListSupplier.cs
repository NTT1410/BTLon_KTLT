using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.ListDB
{
    public class ListSupplier
    {
        public static List<Supplier> readFile(string path)
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                var content = File.ReadAllText(path);
                suppliers = JsonConvert.DeserializeObject<List<Supplier>>(content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return suppliers;
        }
    }
}
