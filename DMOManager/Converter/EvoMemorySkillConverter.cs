using DMOHelper.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DMOHelper.Converter
{
    public class EvoMemorySkillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Evolution.Jogress:
                case Evolution.JogressX:
                case Evolution.Variant:
                    return VMMain.MemoryRatesJog;
                default: return VMMain.MemoryRatesBM;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
