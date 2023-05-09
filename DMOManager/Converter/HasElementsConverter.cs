using System;
using System.Globalization;
using System.Windows.Data;

namespace DMOManager.Converter
{
    public class HasElementsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? count = value as int?;
            if (count != null && count > 0)
            {
                return true;
            }
            else return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
