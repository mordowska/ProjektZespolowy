using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SystemZarzadzaniaAkademikiem.Validators
{
    class Validator
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
    }
}
