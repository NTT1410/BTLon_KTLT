using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang
{
    //public class HDNhapData
    //{
    //    List<HDNhap> hDNhaps { get; set; }
    //}
    public class HDNhap
    {
        public string IDNhap { get; set; }
        public string NgayNhap { get; set; }
        public List<HangNhap> HangNhap { get; set; }
    }
    public class HangNhap
    {
        public string ProductID { get; set; }
        public string Quantity { get; set; }
    }
}
