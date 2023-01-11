using PeriodicTableMaui.ViewModels;

namespace PeriodicTableMaui.Views;

public partial class ElementDetail : ContentPage
{
	public ElementDetail(ElementDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}