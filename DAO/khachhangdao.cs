using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DAO
{
    internal class khachhangdao
    {
        public khachhangdao() { }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh=reader.GetString(0);
                String name=reader.GetString(1);
                String sdt=reader.GetString(2);
                String email=reader.GetString(3);
                DateTime ngaysinh= reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                int tinhtrang=reader.GetInt32(7);
                Boolean gioitinh= reader.GetBoolean(6);
                khachhangdto kh=new khachhangdto(mkh,name,sdt,email,ngaysinh,mtk,tinhtrang,gioitinh);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(khachhangdto khdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into KhachHang values(N'" + khdto.Mkh + "',N'" + khdto.Hoten + "',N'" + khdto.Sdt + "',N'" + khdto.Email + "','" + khdto.Ngaysinh + "','"+khdto.Matk+"','"+khdto.Gioitinh+"','"+khdto.Tinhtrang+"')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(khachhangdto khdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update KhachHang set HoTen= N'"+khdto.Hoten +"',SDT= N'"+khdto.Sdt+"' ,Email= N'"+khdto.Email+"',Ngaysinh='"+khdto.Ngaysinh+ "' ,MaTK='"+khdto.Matk+"',GioiTinh='" + khdto.Gioitinh+"',TinhTrang='"+khdto.Tinhtrang+"'where MaKH='" + khdto.Mkh+ "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
      

    }
}
