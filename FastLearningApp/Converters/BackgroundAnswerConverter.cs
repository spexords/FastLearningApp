using FastLearningApp.Converters.Base;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace FastLearningApp.Converters
{
    public class BackgroundAnswerConverter : BaseMultiValueConverter<BackgroundAnswerConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var isAnswered = (bool)values[0];
            var validAnswer = (bool)values[1];
            var userAnswer = (bool)values[2];
            if (isAnswered)
            {
                if (validAnswer == userAnswer)
                {
                    return Application.Current.FindResource("ValidAnswerBrush");
                }
                else
                {
                    return Application.Current.FindResource("WrongAnswerBrush");
                }
            }
            else
            {
                return Brushes.Transparent;
            }
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
