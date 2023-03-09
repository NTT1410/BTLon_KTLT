using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyKhoHang
{

    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        List<Account> accounts = new List<Account>();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }    
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;
            if(Login(username, password)==true)
            {
                fTableManager f = new fTableManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        bool Login(string username, string passwork)
        {
            foreach (Account acc in accounts)
                if (acc.UserName == username && acc.Password == passwork)
                {
                    fTableManager fTableManager = new fTableManager(acc.Name);
                    fTableManager.nameUser = acc.Name;
                    return true;
                }
            return false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //string path = Application.StartupPath + "\\Source\\DBAccount.json";
            string path = @"D:\OU_3_HK2\KTLT\BaiTapLon\QuanLyKhoHang\QuanLyKhoHang\Source\DBAccount.json";
            accounts = ListAccount.readFile(path);
        }
    }
}
