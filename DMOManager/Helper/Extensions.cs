using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DMOHelper.Helper
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToCollection<T>(this IEnumerable<T> enumerable)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();
            foreach (T item in enumerable)
            {
                collection.Add(item);
            }
            return collection;
        }
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var e in enumerable)
            {
                action(e);
            }
        }
        public static Tuple<long, short, short> GetDMOFormat(this long money)
        {
            long megas = Math.DivRem(money, 1000, out long outBits);
            long teras = Math.DivRem(megas, 1000, out long outMegas);

            return new Tuple<long, short, short>(teras, (short)outMegas, (short)outBits);
        }

        public static long GetLongFormat(this Tuple<long, short, short> dmo)
        {
            return long.Parse(dmo.Item1.ToString() + dmo.Item2.ToTriString() + dmo.Item3.ToTriString());
        }

        public static string DMOToString(this Tuple<long, short, short> dmo)
        {
            if (dmo.Item1 == 0 & dmo.Item2 == 0 && dmo.Item3 == 0)
            {
                return "0 B";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (dmo.Item1 > 0)
                {
                    sb.Append(dmo.Item1.ToString());
                    sb.Append(" T ");
                }

                if (dmo.Item2 > 0)
                {
                    sb.Append(dmo.Item2.ToString());
                    sb.Append(" M ");
                }
                if (dmo.Item3 > 0)
                {
                    sb.Append(dmo.Item3.ToString());
                    sb.Append(" B");
                }
                return sb.ToString();
            }
        }

        public static string ToTriString(this short number)
        {
            if (number == 0)
            {
                return "000";
            }
            else if (number < 10)
            {
                return "00" + number;
            }
            else if (number < 100)
            {
                return "0" + number;
            }
            else return number.ToString();
        }

        public static bool HasEnough(this int? amount)
        {
            if (amount == null)
            {
                return true;
            }
            else if (amount <= 0)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
