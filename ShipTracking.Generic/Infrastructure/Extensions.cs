using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShipTracking.Generic.Infrastructure
{
    public static class Extensions
    {
        public static DateTime? ToDateTime(this string dt)
        {
            try
            {
                if (!string.IsNullOrEmpty(dt))
                    return DateTime.ParseExact(dt, Constants.WipoDateFormat, CultureInfo.InvariantCulture);
            }
            catch
            {
            }

            return null;
        }

        public static string ToPolicingName(this DateTime dt,int ms)
        {
            try
            {
                return "{" + $"ts'{dt.AddMilliseconds(20).ToString("yyyyMMddHH:MM:ssfff")}" + "}0";
            }
            catch
            {
            }

            return null;
        }

        public static double TwoPrecisionNumber(this double number)
        {
            try
            {
                return Convert.ToDouble(Math.Round(Convert.ToDecimal(number), 2));
            }
            catch
            {
            }

            return 0;
        }
    }
}
