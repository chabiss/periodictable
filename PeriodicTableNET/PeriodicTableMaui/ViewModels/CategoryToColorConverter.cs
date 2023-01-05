using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableMaui.ViewModels
{
    public class CategoryToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            string category = (string)value;

            switch (category)
            {
                case "diatomic nonmetal":
                    return Color.FromArgb("#81CC60");
                case "noble gas":
                    return Color.FromArgb("#FFA4C3");
                case "alkali metal":
                    return Color.FromArgb("#FC8362");
                case "alkaline earth metal":
                    return Color.FromArgb("#FFDB62");
                case "metalloid":
                    return Color.FromArgb("#FFDB62");
                case "polyatomic nonmetal":
                    return Color.FromArgb("#81CC60");
                case "post-transition metal":
                    return Color.FromArgb("#C99FC9");
                case "transition metal":
                    return Color.FromArgb("#7DC1FF");
                case "lanthanide":
                    return Color.FromArgb("#628CFF");
                case "actinide":
                    return Color.FromArgb("#62E1BB");
            }

            return Color.FromArgb("#DDDDDD");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
