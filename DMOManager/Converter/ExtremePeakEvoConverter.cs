using DMOHelper.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DMOHelper.Converter
{
    public class ExtremePeakEvoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Evolution.BurstMode:
                case Evolution.BurstModeX:
                case Evolution.Mega:
                case Evolution.MegaX:
                    return true;
                default: return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
