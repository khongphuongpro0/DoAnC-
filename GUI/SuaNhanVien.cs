﻿using Doanqlchdt.BUS;
using Doanqlchdt.DTO;
using Doanqlchdt.connect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Doanqlchdt.GUI
{
    public partial class SuaNhanVien : Form
    {
        private DTO.nhanviendto SelectedEmployee { get; set; }
        static nhanvienbus employeeBUS = new nhanvienbus();
        public SuaNhanVien(DTO.nhanviendto selectedEmployee)
        {
            InitializeComponent();
            SelectedEmployee = selectedEmployee;
            txtMaNV.Text = SelectedEmployee.MaNV.Trim();
            txtHoTen.Text = SelectedEmployee.HoTen;
            txtEmail.Text = SelectedEmployee.Email;
            txtSDT.Text = SelectedEmployee.SDT.Trim();
            dtpNgaySinh.Text = Convert.ToString(SelectedEmployee.NgaySinh);
            if (SelectedEmployee.TrangThai == 1)
            {
                rdbHien.Checked = true;
            }
            else if (SelectedEmployee.TrangThai == 0)
            {
                rdbAn.Checked = false;
            }
            txtMaTK.Text = Convert.ToString(SelectedEmployee.MaTK).Trim();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(dtpNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
            }
            else
            {
                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@gmail\.com$"))
                {
                    MessageBox.Show("Địa chỉ email không hợp lệ!!!");
                    txtEmail.Focus();
                }
                else if (!Regex.IsMatch(txtSDT.Text, @"^[0-9]+$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!!!");
                    txtSDT.Focus();
                }
                else if (Regex.IsMatch(txtHoTen.Text, @"\d"))
                {
                    MessageBox.Show("Họ tên không hợp lệ!!!");
                    txtHoTen.Focus();   
                } 
                else
                {
                    // Thực hiện truy vấn tại đây
                    nhanviendto employeeDTO = new nhanviendto();
                    employeeDTO.MaNV = txtMaNV.Text;
                    employeeDTO.HoTen = txtHoTen.Text;
                    employeeDTO.SDT = txtSDT.Text;
                    employeeDTO.Email = txtEmail.Text;
                    employeeDTO.MaTK = Convert.ToInt32(txtMaTK.Text);
                    DateTime selectedDate = dtpNgaySinh.Value;
                    employeeDTO.NgaySinh = selectedDate.ToString("yyyy-MM-dd");
                    if (rdbHien.Checked)
                    {
                        employeeDTO.TrangThai = 1;
                    }
                    else if (rdbAn.Checked)
                    {
                        employeeDTO.TrangThai = 0;
                    }

                    try
                    {
                        employeeBUS.UpdateEmployee(employeeDTO);
                        MessageBox.Show("Cập nhật thành công");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật: " + ex.Message);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận hủy", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
            }
        }


    }
}
