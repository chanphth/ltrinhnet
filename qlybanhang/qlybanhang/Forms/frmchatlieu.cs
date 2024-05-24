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
    public partial class frmchatlieu : Form
    {
        DataTable tblcl;
        public frmchatlieu()
        {
            InitializeComponent();
        }
        private void load_datagrid()
        {
            string sql;
            sql = "select machatlieu, tenchatlieu from tblchatlieu";
            // viet code lay du lieu tu tblchatlieu hien thi len datagridview
            tblcl = Functions.getdatatotable(sql);
            gridchatlieu.DataSource = tblcl;
            gridchatlieu.Columns[0].HeaderText = "Mã chất liệu";
            gridchatlieu.Columns[1].HeaderText = "Tên chất liệu";
        }
        private void frmchatlieu_Load(object sender, EventArgs e)
        {
            {
                txtmachatlieu.Enabled = false;
                btnluu.Enabled = false;
                btnboqua.Enabled = false;
                //gọi hàm hiển thị dữ liệu lên data gridview
                load_datagrid();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnluu.Enabled = true;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            btnboqua.Enabled = true;
            txtmachatlieu.Enabled = true;
            txtmachatlieu.Focus();
            resetvalue();
        }
        private void resetvalue()
        {
            txtmachatlieu.Text = "";
            txttenchatlieu.Text = "";
        }
        private void btnboqua_Click(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
            txtmachatlieu.Enabled = false;
            resetvalue();
        }
        private void btnluu_Click_1(object sender, EventArgs e)
        {
            if (txtmachatlieu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmachatlieu.Focus();
                return;
            }
            if (txttenchatlieu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenchatlieu.Focus();
                return;
            }
            string sql;
            //kieu chuoi thi viet nhu nay
            sql = "select machatlieu from tblchatlieu where machatlieu =N'" + txtmachatlieu.Text.Trim() + "'";
            //kieu so, ngay thang thi viet nhu nay dung kep cong "+
            if (Functions.checkey(sql))
            {
                MessageBox.Show("Bị trùng mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtmachatlieu.Text = "";
                txtmachatlieu.Focus();
                return;
            }
            //chen du lieu vao bang
            sql = "insert into tblchatlieu(machatlieu,tenchatlieu) values(N'" + txtmachatlieu.Text.Trim() + "',N'" + txttenchatlieu.Text.Trim() + "')";
            Functions.runsql(sql);
            load_datagrid();
            resetvalue(); //de xoa trang o text de chen them du lieu khac
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmachatlieu.Enabled = false;

        }

        private void gridchatlieu_Click(object sender, EventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridchatlieu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtmachatlieu.Text = gridchatlieu.CurrentRow.Cells["machatlieu"].Value.ToString();
            txttenchatlieu.Text = gridchatlieu.CurrentRow.Cells["tenchatlieu"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmachatlieu.Text == "")
            {
                MessageBox.Show("Banj chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridchatlieu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txttenchatlieu.Text == "")
            {
                MessageBox.Show("ban phai nhap ten chat lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenchatlieu.Focus();
                return;
            }
            string sql;
            sql = "update tblchatlieu set tenchatlieu=N'" + txttenchatlieu.Text.Trim() + "' where machatlieu=N'" + txtmachatlieu.Text.Trim() + "'";
            Functions.runsql(sql);
            load_datagrid();
            resetvalue();
            btnboqua.Enabled = false;

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtmachatlieu.Text == "")
            {
                MessageBox.Show("Banj chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridchatlieu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Ban co muon xoa khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql;
                sql = "delete tblchatlieu where machatlieu = N'" + txtmachatlieu.Text.Trim() + "'";
                Functions.runsql(sql);
                load_datagrid();
                resetvalue();
            }

        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
