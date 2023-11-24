using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.obj.Oder
{
    internal class Validate
    {
        public Validate()
        {
        }
        public Boolean kiemtraso(TextBox text)
        {
            String regex = @"^\d+$";
            bool match = Regex.IsMatch(text.Text, regex);
            if (match)
            {
                return false;
            }
            else
            {
                return true;
            }
            return true;
        }
        public Boolean kiemtrarong(TextBox text)
        {
            if (text.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
            return true;
        }
        public Boolean kiemtrachu(TextBox text)
        {
            String regex = @"^[a-zA-Z\sáàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵ]+$";
            bool match = Regex.IsMatch(text.Text, regex);
            if (match)
            {
                return true;
            }
            else
            {
                return false; ;
            }
            return true;
        }
        public Boolean kiemtraemail(TextBox text)
        {
            string regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            bool match = Regex.IsMatch(text.Text, regex);
            if (match)
            {
                return true;
            }
            else
            {
                return false; ;
            }
            return true;
        }
        public Boolean kiemtraphone(TextBox text)
        {
            string regex = @"^\d{10,11}$";
            bool match = Regex.IsMatch(text.Text, regex);
            if (match)
            {
                return true;
            }
            else
            {
                return false; ;
            }
            return true;
        }
        public Boolean kiemtrangaythang(TextBox text)
        {
            string regex = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";
            bool match = Regex.IsMatch(text.Text, regex);
            if (match)
            {
                return true;
            }
            else
            {
                return false; ;
            }
            return true;
        }
    }
}
