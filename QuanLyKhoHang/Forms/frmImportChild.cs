using Newtonsoft.Json;
using QuanLyKhoHang.Instance;
using QuanLyKhoHang.ListDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace QuanLyKhoHang.Forms
{
    public partial class frmImportChild : Form
    {
        private int sum;
        private int maHD;
        private int maSP;
        Random rd = new Random();
        public frmImportChild()
        {
            InitializeComponent();
        }
        DataTable dt;
        DataTable HDNhap;
        List<Product> products = new List<Product>();
        List<HDNhap> hDNhaps= new List<HDNhap>();
        List<Supplier> suppliers = new List<Supplier>();
        List<Category> categories = new List<Category>();
        string path = Application.StartupPath + @"\Source\DBProducts.json";
        string path2 = Application.StartupPath + @"\Source\DBHDNhap.json";
        string path3 = Application.StartupPath + @"\Source\DBSuppliers.json";
        string path4 = Application.StartupPath + @"\Source\DBCategory.json";
        private void frmImportChild_Load(object sender, EventArgs e)
        {
            products = ListProduct.readFile(path);
            hDNhaps = ListHDNhap.readFile(path2);
            suppliers = ListSupplier.readFile(path3);
            categories = ListCategory.readFile(path4);
            randomMHD();
            foreach (HDNhap hdn in hDNhaps)
                while (maHD == int.Parse(hdn.IDNhap))
                    randomMHD();
            txtIDHD.Text = maHD.ToString();
            nSoLuong.Maximum = 50;
            foreach (Supplier s in suppliers)
            {
                cbbSupplier.Items.Add(s.SupplierName);
            }
            foreach (Category c in categories)
            {
                cbbDongsp.Items.Add(c.CategoryName);
            }
            dt = new DataTable();
            //DataRow row;
            addTable(dt);
            DataTable table = new DataTable();
        }
        private void randomMHD()
        {
            maHD = rd.Next(100000, 999999);
        }
        private void randomMSP()
        {
            maSP = rd.Next(1000, 9999);
        }
        private void addTable(DataTable productTable)
        {
            productTable.Columns.Add("CategoryID");
            productTable.Columns.Add("ProductID");
            productTable.Columns.Add("ProductName");
            productTable.Columns.Add("UnitPrice");
            productTable.Columns.Add("Quantity");
            dgvNhap.DataSource = productTable;


            dgvNhap.Columns[0].Width = (int)(dgvNhap.Width * 0.13);
            dgvNhap.Columns[1].Width = (int)(dgvNhap.Width * 0.14);
            dgvNhap.Columns[2].Width = (int)(dgvNhap.Width * 0.25);
            dgvNhap.Columns[3].Width = (int)(dgvNhap.Width * 0.25);
            dgvNhap.Columns[4].Width = (int)(dgvNhap.Width * 0.175);
            dgvNhap.Columns[0].ReadOnly = true;
            dgvNhap.Columns[1].ReadOnly = true;
            dgvNhap.Columns[3].ReadOnly = true;
        }
        private void cbbTensp_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (Product p in products)
            {
                if (p.ProductName == cbbTensp.Text)
                    txtDonGia.Text = p.UnitPrice;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (kiemTra())
                addRow();
        }
        public bool kiemTra()
        {
            if (dgvNhap.Rows.Count == 0)
                return true;
            else
            {
                foreach (DataGridViewRow r in dgvNhap.Rows)
                {
                    if (r.Cells[2].Value.ToString() == cbbTensp.Text)
                    {
                        r.Cells[4].Value = (int.Parse(r.Cells[4].Value.ToString()) + nSoLuong.Value).ToString();
                        return false;
                    }
                }
            }
            return true;
        }
        public void addRow()
        {
            randomMSP();
            DataRow row;
            foreach (Product p in products)
            {
                if (p.ProductName == cbbTensp.Text)
                {
                    row = dt.NewRow();
                    row[0] = p.CategoryID;
                    if (p.CategoryID == "1")
                        row[1] = "IP" + maSP.ToString();
                    else if (p.CategoryID == "2")
                        row[1] = "MB" + maSP.ToString();
                    row[2] = p.ProductName;
                    row[3] = p.UnitPrice;
                    row[4] = nSoLuong.Value.ToString();
                    dt.Rows.Add(row);
                    sum = sum + int.Parse(p.UnitPrice) * int.Parse(nSoLuong.Value.ToString());
                }
            }
            txtSum.Text = sum.ToString();
        }
        private void cbbDongsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTensp.Items.Clear();
            cbbTensp.Text = "";
            foreach (Product p in products)
            {
                foreach(Category c in categories)
                {
                    if (cbbDongsp.SelectedItem.ToString() == c.CategoryName && c.CategoryID == p.CategoryID)
                    {
                        cbbTensp.Items.Add(p.ProductName);
                    }
                }    
            }
        }

        private void saveFile()
        {
            HDNhap h = new HDNhap();
            h.IDNhap = txtIDHD.Text;
            h.NgayNhap = dateTimePicker1.Value.ToString();
            List<HangNhap> n = new List<HangNhap>();
            foreach (DataGridViewRow row in dgvNhap.Rows)
            {
                HangNhap hn = new HangNhap();
                hn.ProductID = row.Cells[1].Value.ToString();
                hn.Quantity = row.Cells[4].Value.ToString();
                hn.CategoryID = row.Cells[0].Value.ToString();
                n.Add(hn);
                h.HangNhap = n;
            }
            h.SupplierID = cbbSupplier.Text;
            hDNhaps.Add(h);

            string path5 = Application.StartupPath + @"\Source\DBHDNhap.json";
            string json = JsonConvert.SerializeObject(hDNhaps);
            File.WriteAllText(path5, json);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            ////Ghi FIle Json
            saveFile();
        }
    }
}
