using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class sanphamdao
    {
        public sanphamdao() { }
        public int selectcount()
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select count (*) from SanPham ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = (int)sqlcommand.ExecuteScalar();
            connect.Close();
            return kq;
        }
        public ArrayList getdsformpage(int ofset, int record)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = string.Format("select * from SanPham ORDER BY MaSP ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                int tinhtrang = reader.GetInt32(7);
                Boolean gioitinh = reader.GetBoolean(6);
                khachhangdto kh = new khachhangdto(mkh, name, sdt, email, ngaysinh, mtk, tinhtrang, gioitinh);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
