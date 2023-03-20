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
using System.Windows.Forms;

namespace QuanLyKhoHang.Forms
{
    public partial class frmProductChild : Form
    {
        public frmProductChild()
        {
            InitializeComponent();
        }

        private int maSP;
        Random rd = new Random();
        List<Product> products = new List<Product>();
        List<Category> categories = new List<Category>();
        DataTable dtProduct;
        DataTable dtCategory;

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string path1 = Application.StartupPath + @"\Source\DBProducts.json";
        string path2 = Application.StartupPath + @"\Source\DBCategory.json";
        private void frmProductChild_Load(object sender, EventArgs e)
        {
            dtProduct = new DataTable();
            dtCategory = new DataTable();
            randomMSP();
            try
            {
                products = ListProduct.readFile(path1);
                categories = ListCategory.readFile(path2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            foreach (Category c in categories)
                comboBox1.Items.Add(c.CategoryName);

        }
        private void randomMSP()
        {
            maSP = rd.Next(1000, 9999);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach(Category c in categories)
            {
                if (comboBox1.Text == c.CategoryName)
                    txtIDHD.Text = c.CategoryID + maSP.ToString();
                else if (comboBox1.Text == c.CategoryName)
                    txtIDHD.Text = c.CategoryID + maSP.ToString();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "" || txtProductName.Text == "" || txtDonGia.Text == "")
            {
                MessageBox.Show("Không được bỏ trống dữ liệu!!!");
            }
            else if (MessageBox.Show("Bạn có thật sự muốn lưu?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MessageBox.Show("Thêm sản phẩm mới thành công");
                if (products == null)
                    products = new List<Product>();
                Product p = new Product();
                p.ProductID = txtIDHD.Text;
                p.ProductName = txtProductName.Text;
                foreach (Category c in categories)
                {
                    if (c.CategoryName == comboBox1.Text)
                    {
                        p.CategoryID = c.CategoryID;
                    }
                }
                p.UnitPrice = txtDonGia.Text;
                p.Quantity = "0";
                products.Add(p);

                string path3 = Application.StartupPath + @"\Source\DBProducts.json";
                string json = JsonConvert.SerializeObject(products);
                File.WriteAllText(path3, json);
                this.Close();
            }
        }
    }
}
