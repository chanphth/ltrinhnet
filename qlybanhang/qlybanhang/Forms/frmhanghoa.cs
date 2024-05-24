using qlybanhang.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlybanhang.Forms
{
    
    public partial class frmhanghoa : Form
        
    {
        DataTable tblhh;
        public frmhanghoa()
        {
            InitializeComponent();
        }
        private void load_datagrid()
        {
            string sql;
            sql = "select mahang,tenhang,machatlieu,soluong,dongianhap,dongiaban from tblhang";
            tblhh = Functions.getdatatotable(sql);
            gridhanghoa.DataSource = tblhh;
            gridhanghoa.Columns[0].HeaderText = "Mã hang";
            gridhanghoa.Columns[1].HeaderText = "Ten hang";
            gridhanghoa.Columns[2].HeaderText = "Mã chat lieu";
            gridhanghoa.Columns[3].HeaderText = "So luong";
            gridhanghoa.Columns[4].HeaderText = "Don gia nhap";
            gridhanghoa.Columns[5].HeaderText = "Don gia ban";
        }
        private void resetvalue()
        {
            txtmahang.Text = "";
            txttenhang.Text = "";
            cbomachatlieu.Text = "";
            txtsoluong.Text = "0";
            txtdongiaban.Text = "0";
            txtdongianhap.Text = "0";
            txtsoluong.Enabled = false;
            txtdongianhap.Enabled = false;
            txtdongiaban.Enabled = false;
            txtanh.Text = "";
            picanh.Image = null;
            txtghichu.Text = "";
        }
        private void frmhanghoa_Load(object sender, EventArgs e)
        {
            txtmahang.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            load_datagrid();
            Functions.fillcombo("select machatlieu, tenchatlieu from tblchatlieu", cbomachatlieu, "machatlieu", "tenchatlieu");
            cbomachatlieu.SelectedIndex = -1; //khong chon vao doi tuong nao
            resetvalue();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "Bitmap|*.bmp|Gif|*.gif|All file|*.*";
            a.FilterIndex = 3;
            a.InitialDirectory = "D:\\";
            a.Title = "Chon hinh anh de hien thi";
            if(a.ShowDialog() == DialogResult.OK)
            {
                picanh.Image = Image.FromFile(a.FileName);
                txtanh.Text = a.FileName;
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(txtmahang.Text =="")
            {
                MessageBox.Show("Ban phai nhap ma hang");
                txtmahang.Focus();
                return;
            }
            if(txttenhang.Text == "")
            {
                MessageBox.Show("Ban phai nhap ten hang");
                txttenhang.Focus();
                return;
            }
            if(cbomachatlieu.Text == "")
            {
                MessageBox.Show("Ban phai chon chat lieu");
                cbomachatlieu.Focus();
                return;
            }
            if(txtanh.Text =="")
            {
                MessageBox.Show("ban phai chon anh de hien thi");
                txtanh.Focus();
                return;
            }
            string sql;
            sql = "select mahang from tblhang where mahang = N'" + txtmahang.Text.Trim() + "'";
            if(Functions.checkey(sql)==true)
            {
                MessageBox.Show("Ma hang nay da co, nhap ma khac");
                txtmahang.Focus();
                txtmahang.Text = "";
                return;
            }
            sql = "insert into tblhang(mahang,tenhang,machatlieu,soluong,dongianhap,dongiaban,anh,ghichu) values(N'"+txtmahang.Text.Trim()+"',N'"+txttenhang.Text.Trim()+"',N'"+cbomachatlieu.SelectedValue.ToString()+"',"+txtsoluong.Text.Trim()+","+txtdongianhap.Text.Trim()+","+txtdongiaban.Text.Trim()+",'"+txtanh.Text.Trim()+"',N'"+txtghichu.Text.Trim()+"')";
            Functions.runsql(sql);
            load_datagrid();
            resetvalue();
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnthem.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmahang.Enabled = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnxoa.Enabled= false;
            btnsua.Enabled= false;
            btnluu.Enabled = true;
            btnboqua.Enabled = true;
            txtmahang.Enabled = true;

        }

        private void gridhanghoa_Click(object sender, EventArgs e)
        {
            txtmahang.Text = gridhanghoa.CurrentRow.Cells["mahang"].Value.ToString();
            txttenhang.Text = gridhanghoa.CurrentRow.Cells["tenhang"].Value.ToString();
            //cbo
            string ma;
            ma = gridhanghoa.CurrentRow.Cells["mahang"].Value.ToString();
            cbomachatlieu.Text = Functions.getfieldvalues("select tenchatlieu from tblchatlieu where machatlieu = N'"+ma+"'");
            txtsoluong.Text = gridhanghoa.CurrentRow.Cells["soluong"].Value.ToString() ;
            txtdongianhap.Text = gridhanghoa.CurrentRow.Cells["dongianhap"].Value.ToString();
            txtdongiaban.Text = gridhanghoa.CurrentRow.Cells["dongiaban"].Value.ToString();
            cbomachatlieu.Text = gridhanghoa.CurrentRow.Cells["machatlieu"].Value.ToString();
            //anh
            txtanh.Text = Functions.getfieldvalues("select anh from tblhang where mahang = N'" + txtmahang.Text + "'");
            picanh.Image = Image.FromFile(txtanh.Text);
            //ghi chu
            txtghichu.Text = Functions.getfieldvalues("select ghichu from tblhang where mahang = N'"+txtmahang.Text+"'");
            btnsua.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if(tblhh.Rows.Count == 0)
            {
                MessageBox.Show("Khong con du lieu!","Thong bao",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if(txtmahang.Text =="")
            {
                MessageBox.Show("ban chua chon ban ghi nao", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if(txttenhang.Text =="")
            {
                MessageBox.Show("Ban phai nhap ten hang", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txttenhang.Focus();
                return;
            }
            if(cbomachatlieu.Text =="")
            {
                MessageBox.Show("Ban phai chon chat lieu", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomachatlieu.Focus();
                return;
            }
            if(txtanh.Text =="")
            {
                MessageBox.Show("Ban phai chon anh minh hoa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtanh.Focus();
                return;
            }
            sql = "update tblhang set tenhang=N'"+txttenhang.Text.Trim()+"',machatlieu = N'"+cbomachatlieu.SelectedValue.ToString()+"', anh = '"+txtanh.Text+"',ghichu=N'"+txtghichu.Text.Trim()+"' where mahang = N'"+txtmahang.Text.Trim()+"'";
            Functions.runsql(sql);
            load_datagrid();
            resetvalue();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if(tblhh.Rows.Count == 0)
            {
                MessageBox.Show("khong con du lieu de chon", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if(txtmahang.Text=="")
            {
                MessageBox.Show("ban chua chon ban ghi nao", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(MessageBox.Show("ban co muon xoa khong","thong bao",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
            {
                sql = "delete tblhang where mahang = N'" + txtmahang.Text.Trim() + "'";
                Functions.runsql(sql);
                load_datagrid();
                resetvalue() ;
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            resetvalue();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmahang.Enabled = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtmahang.Text =="" && txttenhang.Text=="" && cbomachatlieu.Text=="")
            {
                MessageBox.Show("Hay nhap 1 dieu kien tim kiem!!!", "yeu cau", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sql = "select * from tblhang where 1=1";
            if (txtmahang.Text != "")
                sql = sql + "and mahang like N'%" + txtmahang.Text + "%'";
            if (txttenhang.Text != "")
                sql = sql + "and tenhang like N'%" + txttenhang.Text + "%'";
            if (cbomachatlieu.Text != "")
                sql = sql + "and machatlieu like N'%" + cbomachatlieu.SelectedValue + "%'";
            tblhh = Functions.getdatatotable(sql);
            if (tblhh.Rows.Count == 0)
                MessageBox.Show("Khong co ban ghi thoa man dieu kien", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Co" + tblhh.Rows.Count + "ban ghi thoa man dieu kien", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            gridhanghoa.DataSource = tblhh;
            resetvalue();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select mahang, tenhang,machatlieu,soluong,dongianhap,dongiaban,anh,ghichu from tblhang";
            tblhh = Functions.getdatatotable(sql);
            gridhanghoa.DataSource = tblhh;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
