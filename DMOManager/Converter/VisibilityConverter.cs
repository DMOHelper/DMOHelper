using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DMOManager.Converter
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                bool vis = (bool)value;
                if (vis)
                {
                    return Visibility.Visible;
                }
                else return Visibility.Collapsed;
            }
            else return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
