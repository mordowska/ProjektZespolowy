using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SystemZarzadzaniaAkademikiem.Validators
{
    public class Validator
    {
        public static bool EmptyField(string field)
        {
            if (field == null)
                return false;
            var str = field as string;
            return !string.IsNullOrWhiteSpace(str);
        }

        public static bool IndexVal(string index)
        {
            if (index == null)
                return false;
            var tmp = index as string;
            Regex regex = new Regex(@"^([1-9][0-9]{5})$");
            Match match = regex.Match(tmp);
            return match.Success;
        }
        public static bool ValidLogin(string login)
        {
            if (login == null)
                return false;
            var str = login as string;
            return !string.IsNullOrWhiteSpace(str) && str.Length>5;
        }
        public static bool ValidPassword(string password)
        {
            if (password == null)
                return false;
            var str = password as string;
            string patdi = @"\d+"; //match digits
            string patupp = @"[A-Z]+"; //match upper cases
            string patlow = @"[a-z]+"; //match lower cases
            string patsym = @"[`~!@$%^&\\-\\+*/_=,;.':|\\(\\)\\[\\]\\{\\}]+"; //match symbols
            Match id = Regex.Match(str, patdi);
            Match upp = Regex.Match(str, patupp);
            Match low = Regex.Match(str, patlow);
            Match sym = Regex.Match(str, patsym);
            return !string.IsNullOrWhiteSpace(str) && str.Length > 5 && id.Success && upp.Success && low.Success && sym.Success;

        }
    }
}
