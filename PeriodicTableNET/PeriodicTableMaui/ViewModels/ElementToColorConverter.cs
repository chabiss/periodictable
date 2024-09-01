using PeriodicTableData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableMaui.ViewModels
{
    public class ElementToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values[0] == null || values[1] == null || values[2]== null)
            {
                return Color.FromArgb("#DDDDDD");
            }

            ViewMode viewMode = (ViewMode)values[0];
            string category = (string)values[1];
            Lickability lickability = (Lickability)values[2];

            switch (viewMode)
            {
                case ViewMode.Category:
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
                    break;
                case ViewMode.Lickability:
                {
                    switch(lickability)
                    {
                        case Lickability.Sure_Probably_Fine:
                            return Color.FromArgb("#00FF00");
                        case Lickability.Maybe_No_a_Good_Idea:
                            return Color.FromArgb("#FFFF00");
                        case Lickability.You_Should_Not:
                            return Color.FromArgb("#FF0000");
                        case Lickability.Please_Reconsider:
                            return Color.FromArgb("#FF00FF");
                    }
                }
                break;
            }

            return Color.FromArgb("#DDDDDD");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
