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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace QuanLyKhoHang.Forms
{
    public partial class frmExportChild : Form
    {
        private int index;
        private int sum;
        private int maHD;
        Random rd = new Random();
        public frmExportChild()
        {
            InitializeComponent();
        }
        DataTable dt;
        DataTable HDXuat;
        List<Product> products = new List<Product>();
        List<HDXuat> hDXuats= new List<HDXuat>();
        List<Supplier> suppliers = new List<Supplier>();
        List<Category> categories = new List<Category>();
        string path = Application.StartupPath + @"\Source\DBProducts.json";
        string path2 = Application.StartupPath + @"\Source\DBHDXuat.json";
        string path3 = Application.StartupPath + @"\Source\DBSuppliers.json";
        string path4 = Application.StartupPath + @"\Source\DBCategory.json";
        private void frmImportChild_Load(object sender, EventArgs e)
        {
            products = ListProduct.readFile(path);
            hDXuats = ListHDXuat.readFile(path2);
            suppliers = ListSupplier.readFile(path3);
            categories = ListCategory.readFile(path4);
            randomMHD();
            if (hDXuats != null)
            {
                foreach (HDXuat hdx in hDXuats)
                    while (maHD == int.Parse(hdx.IDXuat))
                        randomMHD(); 
            }
            txtIDHD.Text = maHD.ToString();
            nSoLuong.Maximum = 50;
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
        private void addTable(DataTable productTable)
        {
            productTable.Columns.Add("CategoryID");
            productTable.Columns.Add("ProductID");
            productTable.Columns.Add("ProductName");
            productTable.Columns.Add("UnitPrice");
            productTable.Columns.Add("Quantity");
            dgvXuat.DataSource = productTable;


            dgvXuat.Columns[0].Width = (int)(dgvXuat.Width * 0.13);
            dgvXuat.Columns[1].Width = (int)(dgvXuat.Width * 0.14);
            dgvXuat.Columns[2].Width = (int)(dgvXuat.Width * 0.25);
            dgvXuat.Columns[3].Width = (int)(dgvXuat.Width * 0.25);
            dgvXuat.Columns[4].Width = (int)(dgvXuat.Width * 0.175);
            dgvXuat.Columns[0].ReadOnly = true;
            dgvXuat.Columns[1].ReadOnly = true;
            dgvXuat.Columns[3].ReadOnly = true;
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
            if (nSoLuong.Value > int.Parse(txtTonkho.Text))
            {
                MessageBox.Show("Không đủ số lượng trong kho!!!");
            }
            else if (kiemTra())
            {
                txtTonkho.Text = (int.Parse(txtTonkho.Text) - nSoLuong.Value).ToString();
                foreach (Product p in products)
                    if (p.ProductName == cbbTensp.Text)
                        p.Quantity = txtTonkho.Text;
                addRow();
            }
        }
        public bool kiemTra()
        {
            if (dgvXuat.Rows.Count == 0)
                return true;
            else
            {
                if (nSoLuong.Value > int.Parse(txtTonkho.Text))
                {
                    MessageBox.Show("Không đủ số lượng trong kho!!!");
                }
                else foreach (DataGridViewRow r in dgvXuat.Rows)
                {
                    if (r.Cells[2].Value.ToString() == cbbTensp.Text)
                    {
                        txtTonkho.Text = (int.Parse(txtTonkho.Text) - nSoLuong.Value).ToString();
                            foreach (Product p in products)
                                if (p.ProductName == cbbTensp.Text)
                                    p.Quantity = txtTonkho.Text;
                            r.Cells[4].Value = (int.Parse(r.Cells[4].Value.ToString()) + nSoLuong.Value).ToString();
                        return false;
                    }
                }
            }
            return true;
        }
        public void addRow()
        {
            DataRow row;
            if (products != null)
            {
                foreach (Product p in products)
                {
                    if (p.ProductName == cbbTensp.Text)
                    {
                        row = dt.NewRow();
                        row[0] = p.CategoryID;
                        row[1] = p.ProductID;
                        row[2] = p.ProductName;
                        row[3] = p.UnitPrice;
                        row[4] = nSoLuong.Value.ToString();
                        dt.Rows.Add(row);
                        sum = sum + int.Parse(p.UnitPrice) * int.Parse(nSoLuong.Value.ToString());
                    }
                }
                txtSum.Text = sum.ToString(); 
            }
        }
        private void cbbDongsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTensp.Items.Clear();
            cbbTensp.Text = "";
            if (products != null && categories != null)
            {
                foreach (Product p in products)
                {
                    foreach (Category c in categories)
                    {
                        if (cbbDongsp.SelectedItem.ToString() == c.CategoryName && c.CategoryID == p.CategoryID)
                        {
                            cbbTensp.Items.Add(p.ProductName);
                        }
                    }
                }
            }
            else MessageBox.Show("trống dữ liệu");
        }

        private void saveFile()
        {
            if (hDXuats == null)
                hDXuats = new List<HDXuat>();
            HDXuat h = new HDXuat();
            h.IDXuat = txtIDHD.Text;
            h.NgayXuat = dateTimePicker1.Value.ToString();
            List<HangXuat> n = new List<HangXuat>();
            foreach (DataGridViewRow row in dgvXuat.Rows)
            {
                HangXuat hx = new HangXuat();
                hx.ProductID = row.Cells[1].Value.ToString();
                hx.Quantity = row.Cells[4].Value.ToString();
                hx.CategoryID = row.Cells[0].Value.ToString();
                n.Add(hx);
                h.HangXuat = n;
            }
            hDXuats.Add(h);

            //string path5 = Application.StartupPath + @"\Source\DBHDNhap.json";
            string json = JsonConvert.SerializeObject(hDXuats);
            string json1 = JsonConvert.SerializeObject(products);
            File.WriteAllText(path2, json);
            File.WriteAllText(path, json1);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            ////Ghi FIle Json
            
            if (cbbDongsp.Text == "")
                MessageBox.Show("Dòng sản phẩm không được trống!!!");
            else if (cbbTensp.Text == "")
                MessageBox.Show("Tên sản phẩm không được trống!!!");
            else if (dgvXuat.Rows.Count == 0)
                MessageBox.Show("Không có sản phẩm nào trong hóa đơn để thêm!!!");
            else if (MessageBox.Show("Bạn có thật sự muốn lưu?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MessageBox.Show("Lưu hóa đơn thành công");
                saveFile();
                this.Close();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            index = dgvXuat.CurrentCell.RowIndex;
            txtTonkho.Text = (int.Parse(txtTonkho.Text) + int.Parse(dgvXuat.Rows[index].Cells[4].Value.ToString())).ToString();
            foreach (Product p in products)
                if (p.ProductName == cbbTensp.Text)
                    p.Quantity = txtTonkho.Text;
            dgvXuat.Rows.RemoveAt(index);
        }

        private void cbbTensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product p in products)
                if (p.ProductName == cbbTensp.Text)
                    txtTonkho.Text = p.Quantity;
        }

        private void dgvXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                DataGridViewRow row = dgvXuat.Rows[index];
                cbbTensp.Text = row.Cells[2].Value.ToString();
                txtDonGia.Text = row.Cells[3].Value.ToString();
                foreach (Product p in products)
                    if (p.ProductName == cbbTensp.Text)
                        txtTonkho.Text = p.Quantity; 
            }
        }
    }
}
