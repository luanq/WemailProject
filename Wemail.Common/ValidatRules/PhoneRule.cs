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
    public class PhoneRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phone=value.ToString();
            if (string.IsNullOrEmpty(phone)) return new ValidationResult(false, "Phone can not be empty !");
            phone=phone.Trim();
            string pattern= @"^(((13[0-9]{1})|(15[0-35-9]{1})|(17[0-9]{1})|(18[0-9]{1}))+\d{8})$";
            bool isMatch= Regex.IsMatch(phone, pattern);
            string tips = isMatch ? "" : "Phone format error !";
            return new ValidationResult(isMatch,tips);
        }
    }
}
