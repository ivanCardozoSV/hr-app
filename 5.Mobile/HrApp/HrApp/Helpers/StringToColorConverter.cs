using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HrApp.Helpers
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueAsString = value.ToString();
            switch (valueAsString)
            {
                case ("New"):
                    return Color.Green;
                case ("InProgress"):
                    return Color.DarkGray;
                case ("Recall"):
                    return Color.Orange;
                case ("Hired"):
                    return Color.Blue;
                case ("Rejected"):
                    return Color.Red;
                default:
                  return Color.FromHex(value.ToString());
           

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
