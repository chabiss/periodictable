using PeriodicTableMaui.ViewModels;

namespace PeriodicTableMaui.Views
{
    public partial class MainPage : ContentPage
    {
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