﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doanqlchdt.BUS;
using Doanqlchdt.DTO;

namespace Doanqlchdt.GUI
{
    public partial class ThemNhanVien : Form
    {
        nhanviendto employeeDTO = new nhanviendto();
        nhanvienbus employeeBUS = new nhanvienbus();
        
        int i = 0;

        public ThemNhanVien()
        {
            InitializeComponent();
            rdbHien.Checked = true; 
            List<nhanviendto> employees = employeeBUS.GetNhanVien();
            int maNV = employees.Count + 1;
            txtMaNV.Text = maNV.ToString();
            List<string> userIDs = employeeBUS.LoadMaTK();
            cbbMaTK.Items.Clear();
            cbbMaTK.Items.AddRange(userIDs.ToArray());

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận hủy", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
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
                else if (cbbMaTK.SelectedItem == null)
                {
                    MessageBox.Show("Bạn chưa chọn tài khoản cho nhân viên!!!");
                    cbbMaTK.Focus();
                }
                else if (dtpNgaySinh.Value == default(DateTime))
                {
                    MessageBox.Show("Bạn chưa chọn ngày sinh của nhân viên!!!");
                } 
                else if (rdbHien.Checked == false && rdbAn.Checked == false)
                {
                    MessageBox.Show("Hãy chọn trạng thái của nhân viên!!!");
                }
                else
                {
                    // Thực hiện truy vấn tại đây
                    employeeDTO.MaNV = txtMaNV.Text;
                    employeeDTO.HoTen = txtHoTen.Text;
                    employeeDTO.SDT = txtSDT.Text;
                    employeeDTO.Email = txtEmail.Text;
                    employeeDTO.MaTK = Convert.ToInt32(cbbMaTK.SelectedItem);
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
                        employeeBUS.AddEmployee(employeeDTO);
                        MessageBox.Show("Thêm thành công");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật: " + ex.Message);
                    }
                }
            }
        }

    }
}
