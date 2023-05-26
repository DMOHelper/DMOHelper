using System;
using System.Globalization;
using System.Windows.Data;

namespace DMOHelper.Converter
{
    public class SkillPointsMaxLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return 1;
            }
            switch ((double)value)
            {
                case 1.0:
                    return 25;
                case 2.0:
                    return 25;
                case 3.0:
                    return 25;
                case 4.0:
                    return 20;
                case 0.0:
                default:
                    return 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
