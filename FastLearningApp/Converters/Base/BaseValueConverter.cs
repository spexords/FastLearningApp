﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FastLearningApp.Converters.Base
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
  where T : class, new()
    {
        #region Private Members

        private static T mConverter = null;

        #endregion

        #region Markup Extension Methods

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }

        #endregion

        #region Basic Methods

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
