using DMOManager.Helper;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace DMOManager.Converter
{
    public class GetEnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum? obj = value as Enum;
            if (obj != null)
            {
                return obj.GetAttributeOfType<DescriptionAttribute>().Description;
            }
            else return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
