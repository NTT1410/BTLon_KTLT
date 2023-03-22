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
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
        }
        List<HDXuat> hDXuats= new List<HDXuat>();
        List<Product> products = new List<Product>();
        DataTable dtx;
        DataTable tempHDXuat;
        private void btnXuat_Click(object sender, EventArgs e)
        {
            frmExportChild f = new frmExportChild();
            f.ShowDialog();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            time2.Value = DateTime.Now.Date;
            dtx = new DataTable();
            try
            {
                string path = Application.StartupPath + @"\Source\DBHDXuat.json";
                string path2 = Application.StartupPath + @"\Source\DBProducts.json";
                products = ListProduct.readFile(path2);
                hDXuats = ListHDXuat.readFile(path);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            addHDXuat(dtx);
            DataRow row;
            if (hDXuats != null && products != null)
            {
                foreach (HDXuat h in hDXuats)
                {
                    int count = 0;
                    int Dsum = 0;
                    row = dtx.NewRow();
                    row[0] = h.IDXuat;
                    row[1] = h.NgayXuat;
                    foreach (HangXuat hn in h.HangXuat)
                    {
                        foreach (Product p in products)
                        {
                            if (hn.ProductID == p.ProductID)
                                Dsum = Dsum + int.Parse(hn.Quantity) * int.Parse(p.UnitPrice);
                        }
                        count++;
                    }
                    row[2] = count;
                    row[3] = Dsum.ToString("#,###");
                    dtx.Rows.Add(row);
                }
            }
        }
        private void addHDXuat(DataTable dtx)
        {
            dtx.Columns.Add("IDNhap");
            dtx.Columns.Add("NgayXuat");
            dtx.Columns.Add("Count");
            dtx.Columns.Add("Sum");
            dgvXuat.DataSource = dtx;
            dgvXuat.Columns[0].Width = (int)(dgvXuat.Width * 0.25);
            dgvXuat.Columns[1].Width = (int)(dgvXuat.Width * 0.25);
            dgvXuat.Columns[2].Width = (int)(dgvXuat.Width * 0.20);
            dgvXuat.Columns[3].Width = (int)(dgvXuat.Width * 0.25);
        }

        private void btnVIewAll_Click(object sender, EventArgs e)
        {
            dgvXuat.DataSource = dtx;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchHDXuat();
            if (!searchHDXuat())
            {
                MessageBox.Show("Không tìm thấy!!!");
                dgvXuat.DataSource = dtx;
            }
        }

        bool searchHDXuat()
        {
            tempHDXuat = new DataTable();
            addHDXuat(tempHDXuat);
            DataRow row;
            foreach (HDXuat h in hDXuats)
            {
                if (DateTime.Parse(h.NgayXuat) >= time1.Value & DateTime.Parse(h.NgayXuat) <= time2.Value)
                {
                    int count = 0;
                    int Dsum = 0;
                    row = tempHDXuat.NewRow();
                    row[0] = h.IDXuat;
                    row[1] = h.NgayXuat;
                    foreach (HangXuat hn in h.HangXuat)
                    {
                        foreach (Product p in products)
                        {
                            if (hn.ProductID == p.ProductID)
                                Dsum = Dsum + int.Parse(hn.Quantity) * int.Parse(p.UnitPrice);
                        }
                        count++;
                    }
                    row[2] = count;
                    row[3] = Dsum.ToString("#,###");
                    tempHDXuat.Rows.Add(row);
                }
            }
            if (tempHDXuat != null)
                if (tempHDXuat.Rows.Count > 0)
                    return true;
            return false;
        }
    }
}
