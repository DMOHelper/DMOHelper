using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace DMOHelper.Converter
{
    public class MultiBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<bool> list = new List<bool>();
            foreach(object item in values)
            {
                if(item is bool)
                {
                    list.Add((bool)item);
                }
            }
            if (list.Contains(false))
            {
                return false;
            }
            else return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
