using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class khachhangdto
    {

        private String mkh;
        private String hoten;
        private String sdt;
        private String email;
        private DateTime ngaysinh;
        private int matk;
        private int tinhtrang;
        private Boolean gioitinh;

        public string Mkh { get => mkh; set => mkh = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public int Matk { get => matk; set => matk = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
        public bool Gioitinh { get => gioitinh; set => gioitinh = value; }
        public khachhangdto() 
        { 

        }
        public khachhangdto(string mkh, string hoten, string sdt, string email, DateTime ngaysinh, int matk, int tinhtrang, bool gioitinh)
        {
            this.Mkh = mkh;
            this.Hoten = hoten;
            this.Sdt = sdt;
            this.Email = email;
            this.Ngaysinh = ngaysinh;
            this.Matk = matk;
            this.Tinhtrang = tinhtrang;
            this.Gioitinh = gioitinh;
        }


       

    }
}
