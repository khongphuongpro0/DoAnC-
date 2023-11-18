﻿using Doanqlchdt.connect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DAO
{
    internal class ThongKeDAO
    {
        private connectToan connectObj = new connectToan();


        public ThongKeDAO()
        {
        }

        public ArrayList GetSoLuongHoaDonBan()
        {
            ArrayList arrayList = new ArrayList();
            using (SqlConnection connection = connectObj.connection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT MaHDB FROM HoaDonBan", connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    string maHDB = reader.GetString(0);
                    arrayList.Add(maHDB);
                }
                reader.Close();
            }

            return arrayList;
        }

        public ArrayList GetSoLuongKhachHang()
        {
            ArrayList arrayList = new ArrayList();
            using (SqlConnection connection = connectObj.connection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT MaKH FROM KhachHang", connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string maHDB = reader.GetString(0);
                    arrayList.Add(maHDB);
                }
                reader.Close();
            }

            return arrayList;
        }

        public int SoLuongSanPhamBan()
        {
            int soLuong = 0;
            using (SqlConnection connection = connectObj.connection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT SoLuong FROM ChiTietDonBan", connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    soLuong += Convert.ToInt32(reader[0]);
                }
                reader.Close();
            }

            return soLuong;
        }


        public ArrayList GetDSNam()
        {
            ArrayList arrayList = new ArrayList();
            using (SqlConnection connection = connectObj.connection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT YEAR(NgayTao) AS Nam From HoaDonBan ORDER BY Nam DESC", connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while(reader.Read())
                {
                    int nam = Convert.ToInt32(reader["Nam"]);
                    arrayList.Add(nam);
                }
                reader.Close();
            }

            return arrayList;
        }

        public DataTable LayTongTienTheoThangNam()
        {
            DataTable result = new DataTable();
            using (SqlConnection connection = connectObj.connection())
            {

                SqlCommand sqlCommand = new SqlCommand("WITH AllMonths AS (SELECT DISTINCT Thang, Nam FROM" +
                                                        "(SELECT 1 AS Thang UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12) AS Thang, (SELECT DISTINCT YEAR(NgayTao) AS Nam FROM HoaDonBan) AS Nam)" +
                                                        "SELECT AllMonths.Thang, AllMonths.Nam, COALESCE(SUM(HoaDonBan.TongTien), 0) AS TongTienThang FROM AllMonths LEFT JOIN HoaDonBan ON MONTH(HoaDonBan.NgayTao) = AllMonths.Thang AND YEAR(HoaDonBan.NgayTao) = AllMonths.Nam GROUP BY AllMonths.Thang, AllMonths.Nam ORDER BY AllMonths.Nam, AllMonths.Thang;", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(result);
            }
            return result;
        }

        public DataTable LayTongTienTheoThangNam(string year)
        {
            DataTable result = new DataTable();
            using (SqlConnection connection = connectObj.connection())
            {
                string query = "WITH AllMonths AS (SELECT DISTINCT Thang, Nam FROM" +
                    "(SELECT 1 AS Thang UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12) AS Thang, (SELECT DISTINCT YEAR(NgayTao) AS Nam FROM HoaDonBan) AS Nam)" +
                    "SELECT AllMonths.Thang, AllMonths.Nam, COALESCE(SUM(HoaDonBan.TongTien), 0) AS TongTienThang FROM AllMonths LEFT JOIN HoaDonBan ON MONTH(HoaDonBan.NgayTao) = AllMonths.Thang AND YEAR(HoaDonBan.NgayTao) = AllMonths.Nam";

                if (!string.IsNullOrEmpty(year))
                {
                    query += $" WHERE AllMonths.Nam = {year}";
                }

                query += " GROUP BY AllMonths.Thang, AllMonths.Nam ORDER BY AllMonths.Nam, AllMonths.Thang;";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(result);
            }
            return result;
        }

    }
}
