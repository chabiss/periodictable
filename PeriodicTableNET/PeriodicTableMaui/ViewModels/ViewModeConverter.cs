using PeriodicTableData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableMaui.ViewModels
{
    internal class ViewModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ViewMode viewMode = (ViewMode)value;
            switch (viewMode)
            {
                case ViewMode.Category:
                    return 0;
                case ViewMode.Lickability:
                    return 1;
                default:
                    return 0;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int viewMode = (int)value;
            switch (viewMode)
            {
                case 0:
                    return ViewMode.Category;
                case 1:
                    return ViewMode.Lickability;
                default:
                    return ViewMode.Category;
            }
        }
    }
}
