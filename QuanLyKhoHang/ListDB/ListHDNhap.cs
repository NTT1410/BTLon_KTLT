using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QuanLyKhoHang
{
    public class ListHDNhap
    {
        public static List<HDNhap> readFile(string path)
        {
            List<HDNhap> hDNhaps = new List<HDNhap>();
            try
            {
                var content = File.ReadAllText(path);
                hDNhaps = JsonConvert.DeserializeObject<List<HDNhap>>(content);
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return hDNhaps;
        }
    }
}
