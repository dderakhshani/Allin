using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allin.Common.Utilities
{

    public static class DateUtilitiesExtensions
    {

        public static string? ToStringSeparate(
            this DateTime date)
        {

            if (date == null)
            {
                return null;
            }
            return date.ToString("dd MMMM yyyy");
        }
        public static string? ToStringSeparateWithDayName(
            this DateTime date)
        {

            if (date == null)
            {
                return null;
            }
            return date.ToString("ddd, dd MMMM yyyy");
        }
        public static string? ToStringEUNum(
            this DateTime date)
        {

            if (date == null)
            {
                return null;
            }
            return date.ToString("dd/MM/yyyy");
        }
        public static string? ToStringSeparate(
            this DateOnly date)
        {

            if (date == null)
            {
                return null;
            }
            return date.ToString("dd MMMM yyyy");
        }
        public static string? ToStringSeparateWithDayName(
            this DateOnly date)
        {

            if (date == null)
            {
                return null;
            }
            return date.ToString("ddd, dd MMMM yyyy");
        }
        public static string? ToStringEUNum(
            this DateOnly date)
        {

            if (date == null)
            {
                return null;
            }
            return date.ToString("dd/MM/yyyy");
        }

    }
}
