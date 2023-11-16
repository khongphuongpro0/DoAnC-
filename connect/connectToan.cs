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
        //private string connectionString = "Data Source=ToanLD;Initial Catalog=DoAnC#;User ID=sa;Password=Toan03092003;";
        private string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLDACHBDT;Integrated Security=True";

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
