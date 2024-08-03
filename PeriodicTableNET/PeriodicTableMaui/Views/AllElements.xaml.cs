using PeriodicTableMaui.ViewModels;

namespace PeriodicTableMaui.Views;

public partial class AllElements : ContentPage
{
    private MainPageViewModel viewModel;

    public AllElements(MainPageViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
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
}