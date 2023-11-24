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
        private string gioitinh;
        private DateTime ngaysinh;
        private int matk;
        private int tinhtrang;

        public khachhangdto() { }

        public khachhangdto(string mkh, string hoten,string gioitinh, string sdt, string email, DateTime ngaysinh, int Matk,int Tinhtrang)
        {
            this.Mkh = mkh;
            this.Hoten = hoten;
            this.Sdt = sdt;
            this.Email = email;
            this.Gioitinh = gioitinh;
            this.Ngaysinh = ngaysinh;
            this.Matk = Matk;
            this.Tinhtrang = Tinhtrang;
            this.Gioitinh = gioitinh;
 
        }

        public string Mkh { get => mkh; set => mkh = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public int Matk { get => matk; set => matk = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
    }
}
