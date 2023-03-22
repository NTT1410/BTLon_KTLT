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
    public class ListHDXuat
    {
        public static List<HDXuat> readFile(string path)
        {
            List<HDXuat> hDXuats = new List<HDXuat>();
            try
            {
                var content = File.ReadAllText(path);
                hDXuats = JsonConvert.DeserializeObject<List<HDXuat>>(content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return hDXuats;
        }
    }
}
