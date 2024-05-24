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

namespace qlybanhang.Forms
{
    public partial class frmkhachhang : Form
    {
        DataTable tblkh;
        public frmkhachhang()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e) // nút sửa
        {
            if(gridkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Khong con du lieu","Thong bao",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtmakhach.Text == "")
            {
                MessageBox.Show("Ban chua chon ban ghi nao","Thong bao",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(txttenkhach.Text == "")
            {
                MessageBox.Show("Ban phai nhap ten khach", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenkhach.Focus();
                return;
            }
            if(txtdiachi.Text == "")
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;

            }
            if(mskdienthoai.Text == "(   )    -")
            {
                MessageBox.Show("ban phai nhap dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                mskdienthoai.Focus();
                return;
            }
            string sql;
            sql = "update tblkhach set tenkhach = N'"+txttenkhach.Text.Trim()+"',diachi = N'"+txtdiachi.Text.Trim()+"',dienthoai = '"+mskdienthoai.Text+"'where makhach = N'"+txtmakhach.Text.Trim()+"'";
            Functions.runsql(sql);
            load_datagrid();
            resetvalue();
            btnboqua.Enabled = false;
        }
        private void load_datagrid()
        {
            string sql;
            sql = "select * from tblkhach";
            tblkh = Functions.getdatatotable(sql);
            gridkhachhang.DataSource = tblkh;
            gridkhachhang.Columns[0].HeaderText = "Mã khách hàng";
            gridkhachhang.Columns[1].HeaderText = "Tên khách hàng";
            gridkhachhang.Columns[2].HeaderText = "Địa chỉ";
            gridkhachhang.Columns[3].HeaderText = "Điện thoại";

        }
        private void frmkhachhang_Load(object sender, EventArgs e)
        {
            txtmakhach.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            load_datagrid();
        }
        private void resetvalue()
        {
            txtmakhach.Text = "";
            txttenkhach.Text = "";
            txtdiachi.Text = "";
            mskdienthoai.Text = "";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnboqua.Enabled = true;
            btndong.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            resetvalue();
            txtmakhach.Enabled = true;
            txtmakhach.Focus();
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
            txtmakhach.Enabled = false;
            resetvalue() ;
        }

        private void gridkhachhang_Click(object sender, EventArgs e)
        {
            if(btnthem.Enabled == false)
            {
                MessageBox.Show("Ban dang them moi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtmakhach.Focus() ;
                return;
            }
            if(gridkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            txtmakhach.Text = gridkhachhang.CurrentRow.Cells["makhach"].Value.ToString();
            txttenkhach.Text = gridkhachhang.CurrentRow.Cells["tenkhach"].Value.ToString() ;
            txtdiachi.Text = gridkhachhang.CurrentRow.Cells["diachi"].Value.ToString();
            mskdienthoai.Text = gridkhachhang.CurrentRow.Cells["dienthoai"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled=true;
            btnboqua.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtmakhach.Text =="")
            {
                MessageBox.Show("Ban phai nhap ma khach", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtmakhach.Focus() ;
                return;
            }
            if(txttenkhach.Text =="")
            {
                MessageBox.Show("Ban phai nhap ten khach", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txttenkhach.Focus() ;
                return;
            }
            if(txtdiachi.Text == "")
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtdiachi.Focus() ;
                return;
            }
            if(mskdienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Ban phai nhap so dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                mskdienthoai.Focus() ;
                return;
            }
            sql = "select makhach from tblkhach where makhach = N'"+txtmakhach.Text.Trim()+"'";
            if(Functions.checkey(sql))
            {
                MessageBox.Show("Ma khach nay da co", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtmakhach.Focus();
                txtmakhach.Text = "";
                return;
            }
            sql = "insert into tblkhach(makhach,tenkhach,diachi,dienthoai) values (N'" + txtmakhach.Text.Trim() + "',N'" + txttenkhach.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" + mskdienthoai.Text + "')";
            Functions.runsql(sql);
            load_datagrid();
            resetvalue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmakhach.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(txtmakhach.Text == "")
            {
                MessageBox.Show("Ban chua chon ban ghi nao","Thong bao",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(gridkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de xoa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if(MessageBox.Show("Ban co muon xoa khong","Thong bao",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
            {
                string sql;
                sql = "delete tblkhach where makhach = N'"+txtmakhach.Text.Trim()+"'";
                Functions.runsql(sql);
                load_datagrid() ;
                resetvalue();
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
