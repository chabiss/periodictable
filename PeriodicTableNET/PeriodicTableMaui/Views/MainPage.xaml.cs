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