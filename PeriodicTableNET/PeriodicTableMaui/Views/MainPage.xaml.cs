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
            this.DetailPane.PropertyChanged += DetailPane_PropertyChanged;
        }

        private void DetailPane_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsVisible")
            {
                MainPageViewModel viewModel = this.BindingContext as MainPageViewModel;
                if (viewModel != null) {
                    viewModel.IsDetailPaneVisible = this.DetailPane.IsVisible;
                }
            }
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
        }
    }
}