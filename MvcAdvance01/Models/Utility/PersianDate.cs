using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace MvcAdvance01.Models.Utility
{
    public static class PersianDate
    {
        //تعریف متد استاتیک 
        //چون اکستنشن متد است باید داخل پرانتز از کلمه کلیدی دیس استفاده کنیم
        public static DateTime ToPersian(this DateTime dataTime)
        {
            PersianCalendar pc = new PersianCalendar();

            int intYear = pc.GetYear(dataTime);
            int intMonth = pc.GetMonth(dataTime);
            int intDay = pc.GetDayOfMonth(dataTime);

            int intHour = pc.GetHour(dataTime);
            int intMinute = pc.GetMinute(dataTime);

            return new DateTime(intYear, intMonth, intDay, intHour, intMinute, 0);
        }


        public static DateTime ToMiladi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();

            //آبجکت پی سی را اول به دیت تایم تبدیل میکند سپس آیتم ها را میگیرد به ترتیب
            return pc.ToDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, 0);

        }


        public static PersianDateTime ToPersianDateTime(this DateTime dateTime)
        {
            return new PersianDateTime(dateTime);
        }

        public static PersianDateTime ToPersianDateTime(this string dateTime)
        {
            return new PersianDateTime(Convert.ToDateTime(dateTime));
        }
    }
}