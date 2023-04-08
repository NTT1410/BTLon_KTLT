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
    public partial class frmExportDetail : Form
    {
        public frmExportDetail()
        {
            InitializeComponent();
        }
        private int sum = 0;
        List<Product> products = new List<Product>();
        List<RemoveProduct> removeProducts = new List<RemoveProduct>();
        public static Product pDetail = new Product();
        public static HDXuat xDetail = new HDXuat();
        DataTable dt;
        private void frmExportDetail_Load(object sender, EventArgs e)
        {
            try
            {
                products = ListProduct.readFile(Application.StartupPath + @"\Source\DBProducts.json");
                removeProducts = ListRemove.readFile(Application.StartupPath + @"\Source\DBRemoveP.json");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            dt = new DataTable();
            txtIDHD.Text = xDetail.IDXuat;
            dateTimePicker1.Value = DateTime.Parse(xDetail.NgayXuat);
            dt.Columns.Add("ProductID");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Unitprice");
            dt.Columns.Add("Quantity");
            dgvXuatDetail.DataSource = dt;
            dgvXuatDetail.Columns[0].Width = (int)(dgvXuatDetail.Width * 0.25);
            dgvXuatDetail.Columns[1].Width = (int)(dgvXuatDetail.Width * 0.25);
            dgvXuatDetail.Columns[2].Width = (int)(dgvXuatDetail.Width * 0.20);
            dgvXuatDetail.Columns[3].Width = (int)(dgvXuatDetail.Width * 0.25);
            DataRow row;
            foreach (HangXuat n in xDetail.HangXuat)
            {
                row = dt.NewRow();
                row[0] = n.ProductID;
                foreach (Product p in products)
                    if (p.ProductID == n.ProductID)
                    {
                        row[1] = p.ProductName;
                        row[2] = int.Parse(p.UnitPrice).ToString("#,###");
                        sum = sum + int.Parse(p.UnitPrice) * int.Parse(n.Quantity);
                    }
                foreach (RemoveProduct r in removeProducts)
                    if (r.ProductID == n.ProductID)
                    {
                        row[1] = r.ProductName;
                        row[2] = int.Parse(r.UnitPrice).ToString("#,###");
                        sum = sum + int.Parse(r.UnitPrice) * int.Parse(n.Quantity);
                    }
                row[3] = n.Quantity;
                dt.Rows.Add(row);
            }
            txtSum.Text = sum.ToString("#,###");
        }
    }
}
