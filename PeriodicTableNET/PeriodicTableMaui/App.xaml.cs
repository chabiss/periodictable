using PeriodicTableData;

namespace PeriodicTableMaui
{
    public partial class App : Application
    {
        // private PeriodicTableDataEngine DataEngline { get; private set; }
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = new Window(new AppShell());
            return window;
        }
    }
}