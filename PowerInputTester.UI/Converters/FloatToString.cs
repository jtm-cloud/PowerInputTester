using System;
using System.Globalization;
using System.Windows.Data;

namespace PowerInputTester.UI.Converters
{
    public class FloatToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float unwrappedValue = (float)value;
            return unwrappedValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return float.Parse(value as string);
        }
    }
}
