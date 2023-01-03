using PeriodicTableData;

namespace PeriodicTableMaui
{
    public partial class App : Application
    {
        // private PeriodicTableDataEngine DataEngline { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            // this.DataEngline = new PeriodicTableDataEngine();
        }
    }
}