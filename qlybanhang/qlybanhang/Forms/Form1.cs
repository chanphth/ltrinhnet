using qlybanhang.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlybanhang
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }

        private void frmmain_Load(object sender, EventArgs e)
        {
            Functions.ketnoi();
        }

        private void mnuchatlieu_Click(object sender, EventArgs e)
        {
            Forms.frmchatlieu f = new Forms.frmchatlieu();
            f.Show();
        }

        private void mnunhanvien_Click(object sender, EventArgs e)
        {
            Forms.frmnhanvien f = new Forms.frmnhanvien();
            f.Show();
        }

        private void mnuthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnukhachhang_Click(object sender, EventArgs e)
        {
            Forms.frmkhachhang f = new Forms.frmkhachhang();
            f.Show();
        }

        private void mnuhanghoa_Click(object sender, EventArgs e)
        {
            Forms.frmhanghoa f = new Forms.frmhanghoa();
            f.Show();
        }
    }
}
