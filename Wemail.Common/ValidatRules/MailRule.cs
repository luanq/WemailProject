using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wemail.Common.ValidatRules
{
    public class MailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var mail = value.ToString();

            if (string.IsNullOrEmpty(mail)) return new ValidationResult(false, "E-mail can not be empty !");

            mail = mail.Trim();
            //emai正则表达式
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            bool isMatch = Regex.IsMatch(mail, pattern);
            string tips = isMatch ? "" : "Email format error !";
            return new ValidationResult(isMatch, tips);
        }
    }
}
