using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Converters
{
    public class StringOutcomeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Win":
                    return Color.Green;
                case "Draw":
                    return Color.FromHex("#9e9e9e");
                case "Loss":
                    return Color.Red;
            }
            return Color.FromHex("#9e9e9e");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
