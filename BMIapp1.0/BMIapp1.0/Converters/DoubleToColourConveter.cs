using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BMIapp1._0.Converters
{
    internal class DoubleToColourConveter : IValueConverter
    {
        public DoubleToColourConveter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertedVal = (double)value;
            if(convertedVal == 0)
            {
                return Color.Black;
            }
            else if(convertedVal < 21.0)
            {
                return Color.Red;
            }
            else if (convertedVal <= 25)
            {
                return Color.Green;
            }
            else
            {
                return Color.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
