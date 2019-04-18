using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinKit.Converters
{
    public class BoolvalueConverter : IValueConverter
    {
        public BoolvalueConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var view = parameter.GetType().Name;
            var boolValue = (Boolean) value;

            if (string.Equals(view, "Grid"))
            {
                if (boolValue)
                {
                    return true;
                }
                return false;
            }
            else if (string.Equals(view, "ListView"))
            {
                if(boolValue)
                {
                    return false;
                }
                return true;
            }

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
