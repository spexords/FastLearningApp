using FastLearningApp.Converters.Base;
using System;
using System.Globalization;

namespace FastLearningApp.Converters
{
    public class InvertedBooleanConverter : BaseValueConverter<InvertedBooleanConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
