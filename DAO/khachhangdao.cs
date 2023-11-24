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
            sqlcommand.CommandText = "select* from KhachHang";
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
            sqlcommand.Connection = connect;
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int selectcount()
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select count (*) from KhachHang ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection=connect;
            int kq = (int)sqlcommand.ExecuteScalar();
            connect.Close();
            return kq;
        }
        public ArrayList getdsformpage(int ofset,int record )
        {
            
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText =string.Format( "select * from KhachHang ORDER BY MaKH ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY",ofset,record);
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
           public int selectcountpagesearch(String ten,String dieukien)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            dieukien=dieukien.Trim();
            if(ten=="NgaySinh")
            {
                sqlcommand.CommandText = string.Format("select count (*) from KhachHang  Where  CONVERT(NVARCHAR(MAX), {0}, 103) LIKE N'%" + dieukien + "%' ", ten);
            }
            else if(ten=="GioiTinh")
            {
                if (dieukien == "01")
                {
                    sqlcommand.CommandText = string.Format("select count (*) from KhachHang Where GioiTinh In (0,1)");
                }
                else if (dieukien == "0")
                {
                    sqlcommand.CommandText = string.Format("select count(*) from KhachHang Where GioiTinh = 0");
                }
                else if (dieukien == "1")
                {
                    sqlcommand.CommandText = string.Format("select count(*) from KhachHang Where GioiTinh = 1");
                }
            }
            else
            {
                sqlcommand.CommandText = string.Format("select count (*) from KhachHang  Where {0} LIKE N'%" + dieukien + "%' ", ten);
            }
           
            SqlConnection connect = cn.connection();
            sqlcommand.Connection=connect;
            int kq = (int)sqlcommand.ExecuteScalar();
            connect.Close();
            return kq;
        }
        public ArrayList getdsformpageoder(String ten, String dieukien,String dieukiensx,String loaisx,int ofset,int record )
        {
            
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            if(ten=="NgaySinh")
            {
                sqlcommand.CommandText = string.Format("select * from KhachHang Where CONVERT(NVARCHAR(MAX), {0}, 103) LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten,dieukiensx, loaisx,ofset, record);
            }
            else if (ten == "GioiTinh")
            {
                dieukien=dieukien.Trim();
                if(dieukien=="01")
                {
                    sqlcommand.CommandText = string.Format("select * from KhachHang Where GioiTinh In (0,1) ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY",dieukiensx, loaisx,ofset, record);
                }else if(dieukien=="0")
                {
                    sqlcommand.CommandText = string.Format("select * from KhachHang Where GioiTinh = 0 ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", dieukiensx,loaisx, ofset, record);
                }
                else if (dieukien == "1")
                {
                    sqlcommand.CommandText = string.Format("select * from KhachHang Where GioiTinh = 1 ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", dieukiensx, loaisx, ofset, record);
                }

            }
            else
            {
                sqlcommand.CommandText = string.Format("select * from KhachHang Where {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx,loaisx,ofset, record);
            }
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
        public ArrayList getdsformpageodersx(String ten,String sx, int ofset, int record)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
                sqlcommand.CommandText = string.Format("SELECT * FROM KhachHang ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY",ten,sx,ofset,record);
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
