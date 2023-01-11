using PeriodicTableMaui.Views;

namespace PeriodicTableMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ElementDetail), typeof(ElementDetail));
        }
    }
}