using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableMaui.Views
{
    public class ElementDetailPane : VerticalStackLayout
    {
        public ElementDetailPane()
        {

        }

        public bool Show
        {
            get { return (bool)GetValue(ShowProperty); }
            set { SetValue(ShowProperty, value); }
        }

        public static readonly BindableProperty ShowProperty =
       BindableProperty.CreateAttached(
       "Show",
       typeof(bool),
       typeof(ElementDetailPane),
       true,
       propertyChanged: OnDetailedPanePropertyChanged);

        private static void OnDetailedPanePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Handle property changed logic here
        }

        public static void SetShowDetailedPane(BindableObject bindable, bool value)
        {
            bindable.SetValue(ElementDetailPane.ShowProperty, value);
        }

        public static bool GetShowDetailedPane(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ElementDetailPane.ShowProperty);
        }

    }
}
