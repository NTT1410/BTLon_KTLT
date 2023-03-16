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
    public class ListCategory
    {
        public static List<Category> readFile(string path)
        {
            List<Category> categorys = new List<Category>();
            try
            {
                var content = File.ReadAllText(path);
                categorys = JsonConvert.DeserializeObject<List<Category>>(content);


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return categorys;
        }
    }
}
