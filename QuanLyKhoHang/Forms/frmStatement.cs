using QuanLyKhoHang.Instance;
using QuanLyKhoHang.ListDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.Forms
{
    public partial class frmStatement : Form
    {
        public frmStatement()
        {
            InitializeComponent();
        }
        List<Product> products = new List<Product>();
        List<HDNhap> hDNhaps = new List<HDNhap>();
        List<HDXuat> hDXuats = new List<HDXuat>();
        string path = Application.StartupPath + @"\Source\DBProducts.json";
        string path2 = Application.StartupPath + @"\Source\DBHDNhap.json";
        string path3 = Application.StartupPath + @"\Source\DBHDXuat.json";
        private void frmStatement_Load(object sender, EventArgs e)
        {
            products = ListProduct.readFile(path);
            hDNhaps = ListHDNhap.readFile(path2);
            hDXuats = ListHDXuat.readFile(path3);
            txtTonkho.Text = SumProduct().ToString();
            txtGtTonkho.Text = SumValueProduct().ToString("#,##" + " VNĐ");
            txtDNhap.Text = SumHDN().ToString();
            txtDXuat.Text = SumHDX().ToString();
            txtGtNhap.Text = SumValueHDN().ToString("#,##" + " VNĐ");
            txtGtXuat.Text = SumValueHDX().ToString("#,##" + " VNĐ");
        }

        private int SumProduct()
        {
            int sum = 0;
            foreach (Product p in products)
                sum = sum + int.Parse(p.Quantity);
            return sum;
        }
        private int SumValueProduct()
        {
            int sum = 0;
            foreach (Product p in products)
                sum = sum + int.Parse(p.Quantity) * int.Parse(p.UnitPrice);
            return sum;
        }
        private int SumHDN()
        {
            int sum = 0;
            foreach (HDNhap n in hDNhaps)
                sum++;
            return sum;
        }
        private int SumHDX()
        {
            int sum = 0;
            foreach (HDXuat x in hDXuats)
                sum++;
            return sum;
        }
        private int SumValueHDN()
        {
            int sum = 0;
            foreach (HDNhap n in hDNhaps)
            {
                foreach (HangNhap hn in n.HangNhap)
                    foreach (Product p in products)
                        if (p.ProductID == hn.ProductID)
                            sum = sum + int.Parse(hn.Quantity) * int.Parse(p.UnitPrice);
            }    
            return sum;
        }
        private int SumValueHDX()
        {
            int sum = 0;
            foreach (HDXuat x in hDXuats)
            {
                foreach (HangXuat hx in x.HangXuat)
                    foreach (Product p in products)
                        if (p.ProductID == hx.ProductID)
                            sum = sum + int.Parse(hx.Quantity) * int.Parse(p.UnitPrice);
            }
            return sum;
        }
    }
}
