using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KiemTra
    {
        public static bool hasDigit(string a)
        {
            char c;
            for (int i = 0; i < a.Length; i++)
            {
                c = a[i];
                if (Char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool hasLetter(string a)
        {
            char c;
            for (int i = 0; i < a.Length; i++)
            {
                c = a[i];
                if (Char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool hasLetterUpper(string a)
        {
            char c;
            for (int i = 0; i < a.Length; i++)
            {
                c = a[i];
                if (Char.IsLetter(c) && Char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool hasSpecChar(string a)
        {
            char c;
            string specChar = "!@#$%&*()_+=|<>?{}\\\\[\\\\]~-";
            for (int i = 0; i < a.Length; i++)
            {
                c = a[i];
                string d = Char.ToString(c);
                if (specChar.Contains(d))
                    return true;
            }
            return false;
        }
    }
}
