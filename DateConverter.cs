using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikNameHost_ZS
{
    internal class DateConverter
    {
        public static string ConvertToPersianDate(DateTime date)
        {
            PersianCalendar PDate = new PersianCalendar();
            int year = PDate.GetYear(date);
            int month = PDate.GetMonth(date);
            int day = PDate.GetDayOfMonth(date);
            return $"{year}/{month:D}/{day:D}";
        }
    }
}
