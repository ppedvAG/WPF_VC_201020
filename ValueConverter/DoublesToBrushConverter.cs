using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ValueConverter
{
    //MultiBindings benötigen das Interface IMultivalueConverter. Die Convert-Methode empfängt ein value-Array, in welchem die gebundenen Quellen in
    //derselben Reihenfolge wie in der XAML-Deklaration übergeben werden.
    public class DoublesToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(Color.FromArgb((byte)(double)values[3], (byte)(double)values[0], (byte)(double)values[1], (byte)(double)values[2]));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
