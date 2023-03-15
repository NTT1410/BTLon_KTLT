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
    public partial class frmImportChild : Form
    {
        public frmImportChild()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void frmImportChild_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            //DataRow row;
            addTable(dt);

        }
        private void addTable(DataTable productTable)
        {
            //productTable.Columns.Add("ProductID");
            productTable.Columns.Add("ProductName");
            productTable.Columns.Add("Quantity");
            productTable.Columns.Add("ProductTypeID");
            productTable.Columns.Add("UnitPrice");
            dgvNhap.DataSource = productTable;


            dgvNhap.Columns[0].Width = (int)(dgvNhap.Width * 0.20);
            dgvNhap.Columns[1].Width = (int)(dgvNhap.Width * 0.20);
            dgvNhap.Columns[1].ReadOnly = true;
            dgvNhap.Columns[2].Width = (int)(dgvNhap.Width * 0.20);
            dgvNhap.Columns[3].Width = (int)(dgvNhap.Width * 0.20);
            dgvNhap.Columns[4].Width = (int)(dgvNhap.Width * 0.20);
        }
    }
}
