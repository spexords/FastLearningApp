﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FastLearningApp.Converters.Base
{
    public abstract class BaseMultiValueConverter<T> : MarkupExtension, IMultiValueConverter
        where T : class, new()
    {

        private static T mConverter = null;

        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }
    }

}