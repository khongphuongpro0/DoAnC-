﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.connect
{
    internal class connectToan
    {
<<<<<<< HEAD
        //private string connectionString = "Data Source=ToanLD;Initial Catalog=DoAnC#;User ID=sa;Password=Toan03092003;";
        private string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLDACHBDT;Integrated Security=True";
=======
        private string connectionString = "Data Source=ToanLD;Initial Catalog=DoAnC#;User ID=sa;Password=Toan03092003;";
        //private string conn = "Data Source=DESKTOP-5OES69K\\SQLEXPRESS;Initial Catalog=QLDienThoai;User ID=sa;Password=phat7733419";
>>>>>>> 7d37b7b2d53ac482edacc1b20aea44ed80eac356

        public SqlConnection connection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return connection;
        }

        public void closeconect(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Kết nối đã đóng");
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
        }
    }
}
