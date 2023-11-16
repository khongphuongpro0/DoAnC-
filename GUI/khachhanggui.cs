using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class khachhanggui : Form
    {
        public khachhanggui()
        {
            InitializeComponent();
            loadlistview();
        }

        public void loadlistview()
        {
            ListViewItem item1 = new ListViewItem(new string[] { "Item 1", "Item 2" });
            listView1.Items.Add(item1);
            listView1.Columns.Add("Mã KH", 100, HorizontalAlignment.Left); // Thêm các cột vào ListView
            listView1.Columns.Add("Họ Và Tên", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Số Điện Thoại", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Ngày Sinh", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Mã Tài Khoản", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Giới Tính", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Tình Trạng", 100, HorizontalAlignment.Left);
            Graphics g = listView1.CreateGraphics();

            // Điều chỉnh kích thước cho từng cột header
            foreach (ColumnHeader colHeader in listView1.Columns)
            {
                colHeader.Width = TextRenderer.MeasureText(colHeader.Text, listView1.Font).Width + 100; // 10 làm margin
            }

            // Giải phóng đối tượng Graphics
            g.Dispose();
        }
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
             Font HeaderFont = new Font("Arial", 10, FontStyle.Bold);
            Color customHeaderColor = Color.DodgerBlue;
            StringFormat sf = new StringFormat();
            SolidBrush brush = new SolidBrush(Color.White);
            using (Brush hrb = new SolidBrush(customHeaderColor))
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.FillRectangle(hrb, e.Bounds);
                e.Graphics.DrawString(e.Header.Text, HeaderFont,brush, e.Bounds, sf);
                
            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
