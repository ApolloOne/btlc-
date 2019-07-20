using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanHang
{
    class SanPham
    {
        private SqlConnection con;
        public DataTable connect()
        { 
            String cn = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=DBBanHang;Integrated Security=True";
            try
            {
                con = new SqlConnection(cn);
                con.Open();
                String query = "select * FROM Products";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd); //chuyen du lieu ve
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                DataTable dt = new DataTable();
                MessageBox.Show("Không Kết nối tới CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }
        private void disconnect()   // gọi hàm này sau khi đã dùng xong csdl 
        {
            con.Close();
            con.Dispose();
            con = null;
        }
        private bool insertData(String query,SqlConnection con,Products product)
        {
            SqlCommand command = con.CreateCommand();
            command.Connection = con;
            command.CommandText = query;
            try
            {
                command.Parameters.Add("@MaSanPham", SqlDbType.NVarChar).Value = product.MaSanPham;
                command.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value = product.TenSanPham;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
