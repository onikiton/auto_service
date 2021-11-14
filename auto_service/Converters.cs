using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace auto_service
{
    public class DurationInSecondsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string time = TimeSpan.FromSeconds((int)value).Hours.ToString() + " час." + "  " + TimeSpan.FromSeconds((int)value).Minutes.ToString() + " мин."; 
            return time;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }


    public class TimeBeforeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var TimeBifore = ((DateTime)value) - DateTime.Now;
            int HoursBifore = (int)TimeBifore.TotalHours;
            int MinutesBifore = (int)TimeBifore.Minutes;
            string timeBifore = HoursBifore + " час." + "  " + MinutesBifore + " мин.";
            return timeBifore;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var TimeBifore = ((DateTime)value) - DateTime.Now;
            int HoursBifore = Int32.Parse(TimeBifore.Hours.ToString());
            if (HoursBifore < 4) { return new SolidColorBrush(Colors.Red); }
            else {return new SolidColorBrush(Colors.Transparent); }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

    

