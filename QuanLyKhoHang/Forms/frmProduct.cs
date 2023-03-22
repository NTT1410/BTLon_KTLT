using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Reflection;
using QuanLyKhoHang.Instance;
using QuanLyKhoHang.ListDB;

namespace QuanLyKhoHang.Forms
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        List<Product> products = new List<Product>();
        List<RemoveProduct> removeproducts = new List<RemoveProduct>();
        DataTable productTable;

        string path1 = Application.StartupPath + @"\Source\DBRemoveP.json";
        private void frmProduct_Load(object sender, EventArgs e)
        {
            productTable = new DataTable();
            try
            {
                string path2 = Application.StartupPath + @"\Source\DBProducts.json";
                products = ListProduct.readFile(path2);
                removeproducts = ListRemove.readFile(path1);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            if (products!=null)
            {
                DataRow row;
                addTable(productTable);
                foreach (Product p in products)
                {
                    row = productTable.NewRow();
                    row[0] = p.ProductID;
                    row[1] = p.ProductName;
                    row[2] = p.Quantity;
                    row[3] = int.Parse(p.UnitPrice).ToString("#,###");
                    row[4] = p.CategoryID;
                    productTable.Rows.Add(row);
                } 
            }

            ////Ghi FIle Json
            //string path = Application.StartupPath + @"\Source\DBTest.json";
            //string json = JsonConvert.SerializeObject(products);
            //File.WriteAllText(path, json);
        }

        private void addTable(DataTable productTable)
        {
            
            productTable.Columns.Add("ProductID");
            productTable.Columns.Add("ProductName");
            productTable.Columns.Add("Quantity");
            productTable.Columns.Add("UnitPrice (vnđ)");
            productTable.Columns.Add("CategoryID");
            dgvProduct.DataSource = productTable;


            dgvProduct.Columns[0].Width = (int)(dgvProduct.Width * 0.20);
            dgvProduct.Columns[1].Width = (int)(dgvProduct.Width * 0.20);
            dgvProduct.Columns[2].Width = (int)(dgvProduct.Width * 0.15);
            dgvProduct.Columns[3].Width = (int)(dgvProduct.Width * 0.24);           
            dgvProduct.Columns[4].Width = (int)(dgvProduct.Width * 0.15);
        }

        private void txtSearchProduct_Enter(object sender, EventArgs e)
        {
            if(txtSearchProduct.Text == "Nhập mã sản phẩm")
            {
                txtSearchProduct.Text = "";
                txtSearchProduct.ForeColor = Color.Gainsboro;
            }    
        }

        private void txtSearchProduct_Leave(object sender, EventArgs e)
        {
            if( txtSearchProduct.Text == "")
            {
                txtSearchProduct.Text = "Nhập mã sản phẩm";
                txtSearchProduct.ForeColor = Color.DarkGray;
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (txtSearchProduct.Text == "" || txtSearchProduct.Text == "Nhập mã sản phẩm")
                MessageBox.Show("Vui lòng nhập mã sản phẩm cần tìm!!!");
            else
            {
                searchProduct();
                if (!searchProduct())
                {
                    MessageBox.Show("Không tìm thấy!!!");
                    dgvProduct.DataSource = productTable;
                }
            }
        }

        bool searchProduct()
        {
            DataTable tempTable = new DataTable();
            addTable(tempTable);
            DataRow row;
            foreach (Product p in products)
            {
                if (p.ProductID == txtSearchProduct.Text)
                {
                    row = tempTable.NewRow();
                    row[0] = p.ProductID;
                    row[1] = p.ProductName;
                    row[2] = p.Quantity;
                    row[3] = p.UnitPrice;
                    row[4] = p.CategoryID;
                    tempTable.Rows.Add(row);
                    return true;
                }
            }

            return false;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            dgvProduct.DataSource = productTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductChild f = new frmProductChild();
            f.ShowDialog();
        }
        public int index;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                index = dgvProduct.CurrentCell.RowIndex;
                RemoveProduct rmp = new RemoveProduct();
                rmp.ProductID = dgvProduct.Rows[index].Cells[0].Value.ToString();
                rmp.ProductName = dgvProduct.Rows[index].Cells[1].Value.ToString();
                rmp.Quantity = dgvProduct.Rows[index].Cells[2].Value.ToString();
                foreach (Product px in products)
                    if (px.ProductID == rmp.ProductID)
                        rmp.UnitPrice = px.UnitPrice;
                rmp.CategoryID = dgvProduct.Rows[index].Cells[4].Value.ToString();
                rmp.NgayXoa = DateTime.Now.ToString();
                removeproducts.Add(rmp);
                dgvProduct.Rows.RemoveAt(index);
                List<Product> prd = new List<Product>();
                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    Product p = new Product();
                    p.ProductID = row.Cells[0].Value.ToString();
                    p.ProductName = row.Cells[1].Value.ToString();
                    p.Quantity = row.Cells[2].Value.ToString();
                    foreach (Product px in products)
                        if (px.ProductID == p.ProductID)
                            p.UnitPrice = px.UnitPrice;
                    p.CategoryID = row.Cells[4].Value.ToString();
                    prd.Add(p);
                }
                string json = JsonConvert.SerializeObject(prd);
                string json1 = JsonConvert.SerializeObject(removeproducts);
                string path = Application.StartupPath + @"\Source\DBProducts.json";
                File.WriteAllText(path, json);
                File.WriteAllText(path1, json1);
                MessageBox.Show("Xóa thành công!!!");
            }
                
        }
    }
}
