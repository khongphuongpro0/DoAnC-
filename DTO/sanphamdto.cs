using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class sanphamdto
    {
        private String masp;
        private String tensp;
        private String maloai;
        private int  gianhap;
        private int giaban;
        private String mota;
        private byte[] imageData;
        private int soluong;

        public sanphamdto()
        {
        }

        public sanphamdto(string masp, string tensp, string maloai, int gianhap, int giaban, string mota, byte[] imageData, int soluong)
        {
            this.Masp = masp;
            this.Tensp = tensp;
            this.Maloai = maloai;
            this.Gianhap = gianhap;
            this.Giaban = giaban;
            this.Mota = mota;
            this.ImageData = imageData;
            this.Soluong = soluong;
        }

        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Maloai { get => maloai; set => maloai = value; }
        public int Gianhap { get => gianhap; set => gianhap = value; }
        public int Giaban { get => giaban; set => giaban = value; }
        public string Mota { get => mota; set => mota = value; }
        public byte[] ImageData { get => imageData; set => imageData = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
