using DMOManager.Helper;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DMOManager.Converter
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long? money = value as long?;
            if (money != null)
            {
                if (money == -1)
                {
                    return "Farmed";
                }
                else if(money == -2)
                {
                    return "Keep dreaming..";
                }
                else if(money == -3)
                {
                    return "Suspicious..";
                }
                else return ((long)money).GetDMOFormat().DMOToString();
            }
            else return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
