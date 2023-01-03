using PeriodicTableMaui.ViewModels;

namespace PeriodicTableMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
            Task.Run(async () => await viewModel.RefreshView());
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
        }
    }
}