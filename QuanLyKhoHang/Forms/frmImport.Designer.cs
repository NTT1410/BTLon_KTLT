namespace QuanLyKhoHang.Forms
{
    partial class frmImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvHDNhap = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.time1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.time2 = new System.Windows.Forms.DateTimePicker();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnDetail = new FontAwesome.Sharp.IconButton();
            this.btnNhap = new FontAwesome.Sharp.IconButton();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.btnVIewAll = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDNhap)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvHDNhap);
            this.panel1.Location = new System.Drawing.Point(12, 94);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 386);
            this.panel1.TabIndex = 0;
            // 
            // dgvHDNhap
            // 
            this.dgvHDNhap.AllowUserToAddRows = false;
            this.dgvHDNhap.AllowUserToDeleteRows = false;
            this.dgvHDNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHDNhap.Location = new System.Drawing.Point(0, 0);
            this.dgvHDNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvHDNhap.Name = "dgvHDNhap";
            this.dgvHDNhap.ReadOnly = true;
            this.dgvHDNhap.RowHeadersWidth = 51;
            this.dgvHDNhap.RowTemplate.Height = 24;
            this.dgvHDNhap.Size = new System.Drawing.Size(920, 386);
            this.dgvHDNhap.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.time1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.time2);
            this.panel2.Controls.Add(this.btnVIewAll);
            this.panel2.Controls.Add(this.iconButton1);
            this.panel2.Controls.Add(this.btnDetail);
            this.panel2.Controls.Add(this.btnNhap);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 76);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(1, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(919, 2);
            this.label3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ";
            // 
            // time1
            // 
            this.time1.Location = new System.Drawing.Point(35, 42);
            this.time1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.time1.Name = "time1";
            this.time1.Size = new System.Drawing.Size(200, 22);
            this.time1.TabIndex = 5;
            this.time1.Value = new System.DateTime(2000, 1, 1, 22, 15, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(256, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến";
            // 
            // time2
            // 
            this.time2.Location = new System.Drawing.Point(303, 42);
            this.time2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.time2.Name = "time2";
            this.time2.Size = new System.Drawing.Size(200, 22);
            this.time2.TabIndex = 6;
            this.time2.Value = new System.DateTime(2023, 3, 15, 0, 0, 0, 0);
            // 
            // iconButton1
            // 
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(213, 2);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(108, 25);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "Xuất file";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDetail.IconColor = System.Drawing.Color.Black;
            this.btnDetail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDetail.Location = new System.Drawing.Point(100, 2);
            this.btnDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(108, 25);
            this.btnDetail.TabIndex = 2;
            this.btnDetail.Text = "Xem chi tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnNhap
            // 
            this.btnNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhap.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnNhap.IconColor = System.Drawing.Color.Black;
            this.btnNhap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNhap.Location = new System.Drawing.Point(7, 2);
            this.btnNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(88, 25);
            this.btnNhap.TabIndex = 2;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSearch.IconColor = System.Drawing.Color.Black;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.Location = new System.Drawing.Point(531, 41);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Xem";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnVIewAll
            // 
            this.btnVIewAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVIewAll.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnVIewAll.IconColor = System.Drawing.Color.Black;
            this.btnVIewAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVIewAll.Location = new System.Drawing.Point(594, 41);
            this.btnVIewAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVIewAll.Name = "btnVIewAll";
            this.btnVIewAll.Size = new System.Drawing.Size(108, 25);
            this.btnVIewAll.TabIndex = 2;
            this.btnVIewAll.Text = "Xem tất cả";
            this.btnVIewAll.UseVisualStyleBackColor = true;
            this.btnVIewAll.Click += new System.EventHandler(this.btnVIewAll_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(944, 492);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImport";
            this.Load += new System.EventHandler(this.frmImport_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDNhap)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnSearch;
        private System.Windows.Forms.DataGridView dgvHDNhap;
        private FontAwesome.Sharp.IconButton btnDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker time1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker time2;
        private FontAwesome.Sharp.IconButton btnNhap;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnVIewAll;
    }
}