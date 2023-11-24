using Doanqlchdt.BUS;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class sanphamgui : Form
    {
        static loaisanphambus khachhbus = new loaisanphambus();
        private Boolean timkiem = false;
        private Boolean sx = false;
        private Boolean temppage = true;
        private Boolean side = false;
        private int totalpage = 0;
        private String tenlcsx = "";
        private String loaisx = "";
        private String tempsx = "";
        private String temploaisx = "";
        private static int record = 23;
        private static int temp = 1;
        private static int ofset = (temp - 1) * record;
        private String ketquatim = "";
        private String ten = "";
        private int totalpageorder = 0;
        private static int recordorder = 3;
        private static int temporder = 1;
        private static int ofsetorder = (temporder - 1) * recordorder;
        //private ArrayList ds = khachhbus.getdspage(ofset, record);
        private System.Windows.Forms.Button[] btnarray;
        private System.Windows.Forms.Button[] btnarrayod;
        public sanphamgui()
        {
            InitializeComponent();
        }
    }
}
