using DMOHelper.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DMOHelper.Converter
{
    public class ViceColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ViceType type = (ViceType)value;
            switch (type)
            {
                case ViceType.Beg1:
                    return "LightBlue";
                case ViceType.Beg2:
                    return "LightSteelBlue";
                case ViceType.Adv0:
                    return "MediumSlateBlue";
                case ViceType.Adv1:
                    return "Teal";
                case ViceType.Adv2:
                    return "SeaGreen";
                case ViceType.OT103:
                    return "Orange";
                case ViceType.TrueVice:
                    return new LinearGradientBrush(Colors.RoyalBlue, Colors.Crimson, 45.0);
                case ViceType.Beg0:
                default:
                    return "LightGray";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
