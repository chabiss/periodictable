using PeriodicTableMaui.ViewModels;

namespace PeriodicTableMaui.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.DetailPane.PropertyChanged += DetailPane_PropertyChanged;
            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            this.BindingContext = this.viewModel;
            await RefreshViewAsync();
        }

        private async Task RefreshViewAsync()
        {
            await this.Dispatcher.DispatchAsync(async () =>
            {
                await viewModel.RefreshView();
            });
        }

        private void DetailPane_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Show")
            {
                MainPageViewModel viewModel = this.BindingContext as MainPageViewModel;
                if (viewModel != null)
                {
                    // <local:ElementDetailPane local:ElementDetailPane.Show="{Binding IsDetailPaneVisible, Mode=OneWayToSource}">
                    // The bound property gets set to false, but never to true even though we received the event here
                    viewModel.IsDetailPaneVisible = this.DetailPane.IsVisible;
                }
            }
        }
    }
}