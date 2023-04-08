using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.Instance
{
    public class HDXuat
    {
        public string IDXuat { get; set; }
        public string NgayXuat { get; set; }
        public List<HangXuat> HangXuat { get; set; }
    }
    public class HangXuat
    {
        public string ProductID { get; set; }
        public string Quantity { get; set; }
        public string CategoryID { get; set; }
    }
}
