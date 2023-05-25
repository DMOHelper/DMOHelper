using System;
using System.Globalization;
using System.Windows.Data;

namespace DMOHelper.Converter
{
    public class SkillPointsMaxLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case 1:
                    return 25;
                case 2:
                    return 25;
                case 3:
                    return 25;
                case 4:
                    return 20;
                case 0:
                case null:
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
