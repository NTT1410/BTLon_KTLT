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

namespace QuanLyKhoHang.Forms
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        public void writeFile(string path)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }
        List<Product> products = new List<Product>();
        DataTable productTable;
        private void frmProduct_Load(object sender, EventArgs e)
        {
            productTable = new DataTable();
            productTable.Columns.Add("ProductID");
            productTable.Columns.Add("ProductName");
            productTable.Columns.Add("Quantity");
            productTable.Columns.Add("ProductTypeID");
            productTable.Columns.Add("UnitPrice");
            dgvProduct.DataSource = productTable;


            dgvProduct.Columns[0].Width = (int)(dgvProduct.Width * 0.20);
            dgvProduct.Columns[1].Width = (int)(dgvProduct.Width * 0.20);
            dgvProduct.Columns[2].Width = (int)(dgvProduct.Width * 0.20);
            dgvProduct.Columns[3].Width = (int)(dgvProduct.Width * 0.20);
            dgvProduct.Columns[4].Width = (int)(dgvProduct.Width * 0.20);

            try
            {
                string path2 = Application.StartupPath + @"\Source\DBProducts.json";
                products = ListProduct.readFile(path2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            addProducts(products);

            //Ghi FIle Json
            string path = Application.StartupPath + @"\Source\DBTest.json";
            string json = JsonConvert.SerializeObject(products);
            File.WriteAllText(path, json);
        }

        private void addProducts(List<Product> products)
        {
            DataRow row;
            foreach (Product p in products)
            {
                row = productTable.NewRow();
                row[0] = p.ProductID;
                row[1] = p.ProductName;
                row[2] = p.Quantity;
                row[3] = p.ProductTypeID;
                row[4] = p.UnitPrice;
                productTable.Rows.Add(row);
            }
        }

        private void txtSearchProduct_Enter(object sender, EventArgs e)
        {
            if(txtSearchProduct.Text == "Nhập mã sản phẩm")
            {
                txtSearchProduct.Text = "";
                txtSearchProduct.ForeColor = Color.Black;
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
            productTable.Clear();   
            DataRow row;
            foreach (Product p in products)
            {
                if(p.ProductID == txtSearchProduct.Text)
                {
                    row = productTable.NewRow();
                    row[0] = p.ProductID;
                    row[1] = p.ProductName;
                    row[2] = p.Quantity;
                    row[3] = p.ProductTypeID;
                    row[4] = p.UnitPrice;
                    productTable.Rows.Add(row);
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            productTable.Clear();
            addProducts(products);
        }
    }
}
