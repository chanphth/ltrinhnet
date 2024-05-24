using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace qlybanhang.Function
{
    internal class Functions
    {
        public static SqlConnection conn;
        public static string connstring;

        public static void ketnoi()
        {
            connstring = "Data Source=DESKTOP-59JVI9F\\MSSQLSERVER02;Initial Catalog=qlbh;Integrated Security=True;TrustServerCertificate=True";
            conn = new SqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            MessageBox.Show("Ket noi thanh cong");
        }
        public static void ngatketnoi()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        public static DataTable getdatatotable(string sql)
        {
            SqlDataAdapter a = new SqlDataAdapter();
            a.SelectCommand = new SqlCommand();
            a.SelectCommand.Connection = Functions.conn;
            a.SelectCommand.CommandText = sql;

            DataTable bang = new DataTable();
            a.Fill(bang);
            return bang;
        }
        public static bool checkey(string sql)
        {
            SqlDataAdapter a = new SqlDataAdapter();
            a.SelectCommand = new SqlCommand();
            a.SelectCommand.Connection = Functions.conn;
            a.SelectCommand.CommandText = sql;

            DataTable bang = new DataTable();
            a.Fill(bang);
            if (bang.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static void runsql(string sql)
        {
            SqlCommand a = new SqlCommand();
            a.Connection = Functions.conn;
            a.CommandText = sql;
            try
            {
                a.ExecuteNonQuery();
            }
            catch (System.Exception loi)
            {
                MessageBox.Show(loi.ToString());
            }
            a.Dispose();
            a = null;
        }
        public static bool isdate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0])>=1)&& (Convert.ToInt32(parts[0])<=12) && Convert.ToInt32(parts[1])>=1 && Convert.ToInt32(parts[1]) <=31 && Convert.ToInt32(parts[2]) >= 1900)
                return true;
            else return false;
        }
        public static string convertdatetime(string d)
        {
            string[] parts = d.Split('/');
            string dt = string.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }
        public static void fillcombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter a = new SqlDataAdapter();
            a.SelectCommand = new SqlCommand();
            a.SelectCommand.Connection = Functions.conn;
            a.SelectCommand.CommandText = sql;
            DataTable bang = new DataTable();
            a.Fill(bang);
            cbo.DataSource = bang;
            cbo.ValueMember = ma; //truong lay gia tri
            cbo.DisplayMember = ten; //truong hien thi
        }
        public static string getfieldvalues(string sql)
        {
            string ma = "";
            SqlCommand a = new SqlCommand(sql,Functions.conn);
            SqlDataReader reader;
            reader = a .ExecuteReader();
            while(reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }
    }
}
