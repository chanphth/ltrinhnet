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
    public partial class frmnhanvien : Form
    {
        DataTable tblnv;
        public frmnhanvien()
        {
            InitializeComponent();
        }
        private void load_datagrid()
        {
            string sql;
            sql = "select * from tblnhanvien";
            tblnv = Functions.getdatatotable(sql);
            gridnhanvien.DataSource = tblnv;
            gridnhanvien.Columns[0].HeaderText = "Mã nhân viên";
            gridnhanvien.Columns[1].HeaderText = "Tên nhân viên";
            gridnhanvien.Columns[2].HeaderText = "Giới tính";
            gridnhanvien.Columns[3].HeaderText = "Địa chỉ";
            gridnhanvien.Columns[4].HeaderText = "Điện thoại";
            gridnhanvien.Columns[5].HeaderText = "Ngày sinh";
            // câu lệnh cho không phép ng dùng sửa trực tiếp dữ liệu từ giao diện ng dùng
            //gridnhanvien.AllowUserToAddRows = false;
            //gridnhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void frmnhanvien_Load(object sender, EventArgs e) //form load để hiển thị dữ liệu lên datagridview
        {
            txtmanhanvien.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            load_datagrid();
            gridnhanvien.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnboqua.Enabled = true;
            resetvalue();
            txtmanhanvien.Enabled = true;
            txtmanhanvien.Focus();
            
        }
        private void resetvalue()
        {
            txtmanhanvien.Text = "";
            txttennhanvien.Text = "";
            txtdiachi.Text = "";
            chkgioitinh.Checked = false;
            mskdienthoai.Text = "";
            mskngaysinh.Text = "";
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
            txtmanhanvien.Enabled=false;
            resetvalue();
        }

        private void gridnhanvien_Click(object sender, EventArgs e)
        {
            if(btnthem.Enabled==false)
            {
                MessageBox.Show("Ban dang o che do them moi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhanvien.Focus();
                return;
            }
            if(tblnv.Rows.Count==0)
            {
                MessageBox.Show("Khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            txtmanhanvien.Text = gridnhanvien.CurrentRow.Cells["manhanvien"].Value.ToString();
            txttennhanvien.Text = gridnhanvien.CurrentRow.Cells["tennhanvien"].Value.ToString();
            if (gridnhanvien.CurrentRow.Cells["gioitinh"].Value.ToString()=="Nam")
                chkgioitinh.Checked = true;
            else 
                chkgioitinh.Checked = false;
            txtdiachi.Text = gridnhanvien.CurrentRow.Cells["diachi"].Value.ToString();
            mskdienthoai.Text = gridnhanvien.CurrentRow.Cells["dienthoai"].Value.ToString();
            mskngaysinh.Text = gridnhanvien.CurrentRow.Cells["ngaysinh"].Value.ToString();
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(txtmanhanvien.Text =="")
            {
                MessageBox.Show("Ban phai nhap ma nhan vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhanvien.Focus();
                return; 
            }
            if (txttennhanvien.Text == "")
            {
                MessageBox.Show("Ban phai nhap ten nhan vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttennhanvien.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return;
            }
            if(mskdienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Ban phai nhap so dien thoai","Thong bao",MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskdienthoai.Focus();   
                return;
            }
            if(mskngaysinh.Text== "  /  /")
            {
                MessageBox.Show("Ban phai nhap ngay sinh", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                mskngaysinh.Focus();
                return;
            }
            string gt,sql;
            if (chkgioitinh.Checked == true)
                gt = "Nam";
            else gt = "Nu";
            sql = "select manhanvien from tblnhanvien where manhanvien =N'"+txtmanhanvien.Text.Trim()+"'";
            if(Functions.checkey(sql))
            {
                MessageBox.Show("Ma nhan vien nay da co", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtmanhanvien.Focus();
                txtmanhanvien.Text = "";
                return;
            }
            sql = "insert into tblnhanvien(manhanvien,tennhanvien,gioitinh,diachi,dienthoai,ngaysinh) values (N'"+txtmanhanvien.Text.Trim()+"',N'"+txttennhanvien.Text.Trim()+"',N'"+gt+"',N'"+txtdiachi.Text.Trim()+"','"+mskdienthoai.Text+"','"+Functions.convertdatetime(mskngaysinh.Text)+"')";
            Functions.runsql(sql);
            load_datagrid();
            resetvalue();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtmanhanvien.Text == "")
            {
                MessageBox.Show("Ban chua chon ban ghi nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (gridnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Ban phai nhap ten nhan vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtmanhanvien.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtdiachi.Focus();
                return;
            }
            if (mskdienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Ban phai nhap so dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                mskdienthoai.Focus();
                return;
            }
            if (mskngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Ban phai nhap ngay sinh", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                mskngaysinh.Focus();
                return;
            }
            if (!Functions.isdate(mskngaysinh.Text))
            {
                MessageBox.Show("Ban phai nhap lai ngay sinh", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return;
            }
            if (chkgioitinh.Checked == true)
                gt = "Nam";
            else gt = "Nu";
            sql = "update tblnhanvien set tennhanvien = N'" + txttennhanvien.Text.Trim() + "',diachi = N'" + txtdiachi.Text.Trim() + "',dienthoai = '" + mskdienthoai.Text + "', gioitinh = N'" + gt + "',ngaysinh='" + Functions.convertdatetime(mskngaysinh.Text) + "' where manhanvien = N'" + txtmanhanvien.Text.Trim() + "'";
            Functions.runsql(sql);
            load_datagrid();
            resetvalue();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(txtmanhanvien.Text=="")
            {
                MessageBox.Show("Ban chua chon ban ghi nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(gridnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("khong co du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if ( MessageBox.Show("ban co muon xoa khong","Thong bao",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
            {
                string sql;
                sql = "delete tblnhanvien where manhanvien = N'"+txtmanhanvien.Text.Trim()+"'";
                Functions.runsql(sql);
                load_datagrid();
                resetvalue();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
