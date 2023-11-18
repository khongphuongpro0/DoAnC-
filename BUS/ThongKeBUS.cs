﻿using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.BUS
{
    internal class ThongKeBUS
    {
        ThongKeDAO thongKeDao = new ThongKeDAO();

        public ArrayList GetSoLuongHoaDonBan()
        {
            return thongKeDao.GetSoLuongHoaDonBan();
        }

        public ArrayList GetSoLuongKhachHang()
        {
            return thongKeDao.GetSoLuongKhachHang();
        }

        public int SoLuongSanPhamBan()
        { 
            return thongKeDao.SoLuongSanPhamBan();
        } 

            public ArrayList GetDSNam()
        {
            return thongKeDao.GetDSNam();
        }

        public DataTable LayTongTienTheoNam()
        {
            return thongKeDao.LayTongTienTheoThangNam();
        }

        public DataTable LayTongTienTheoNam(string year)
        {
            return thongKeDao.LayTongTienTheoThangNam(year);
        }
    }
}
