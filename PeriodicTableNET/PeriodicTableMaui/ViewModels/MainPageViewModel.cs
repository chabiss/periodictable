using PeriodicTableData;
using PeriodicTableMaui.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableMaui.ViewModels
{
    public enum ViewMode
    {
        Category,
        Lickability
    }

    public partial class MainPageViewModel : BaseViewModel
    {
        private PeriodicTableDataEngine dataEngine;

        public ObservableCollection<ElementViewModel> Elements { get; } = new();

        public ObservableCollection<ColorLegendItemsModel> ColorLegendItems { get; } = new();

        public MainPageViewModel(PeriodicTableDataEngine dataEngine)
        {
            Title = "Periodic Table of Elements";
            this.dataEngine = dataEngine;
            this.viewMode = ViewMode.Category;
            this.PropertyChanged += this.OnViewModelPropertyChanged;
            this.UpdateColorLegendItems();
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        bool isDetailPaneVisible;

        [ObservableProperty]
        ViewMode viewMode;

        [ObservableProperty]
        ElementViewModel selectedElement;

        [RelayCommand]
        public async Task GetTableElementsAsync()
        {
            await this.RefreshView();
        }

        public async Task<PeriodicTableDataModel> GetDataModelAsync()
        {
            PeriodicTableDataModel dataModel = await this.dataEngine.InitializeData();
            return dataModel;
        }

        public async Task RefreshView()
        {
            if (this.IsRefreshing)
            {
                return;
            }

            this.IsRefreshing = true;
            PeriodicTableDataModel dataModel = await this.GetDataModelAsync();
            if (dataModel != null)
            {
                this.Elements.Clear(); ;
                foreach (var element in dataModel.Elements)
                {
                    this.Elements.Add(new ElementViewModel(element));
                }
            }
            this.IsRefreshing = false;
        }

        [RelayCommand]
        async Task GoToDetails(ElementViewModel elementViewModel)
        {
            if (elementViewModel == null)
            {
                return;
            }

            if (this.SelectedElement != null)
            {
                this.SelectedElement.IsSelected = false;
            }

            this.SelectedElement = elementViewModel;
            this.SelectedElement.IsSelected = true;


            // If the detail pane is visible, we don't want to navigate to the detail page. 
            if (this.IsDetailPaneVisible)
            {
                return;
            }

            await Shell.Current.GoToAsync(nameof(ElementDetail), true, new Dictionary<string, object>
            {
                {"element", this.SelectedElement.Element }
            });
        }

        [RelayCommand]
        async Task GoToListElements(MainPageViewModel mainPageViewModel)
        {
            await Shell.Current.GoToAsync(nameof(AllElements), true, new Dictionary<string, object>
            {
            });
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewMode))
            {
                // Handle ViewMode changes
                OnViewModeChanged();
            }
        }

        private void OnViewModeChanged()
        {
            this.UpdateColorLegendItems();
           //  _ = this.RefreshView();
        }

        private void UpdateColorLegendItems()
        {
            this.ColorLegendItems.Clear();

            switch (this.ViewMode)
            {
                case ViewMode.Category:
                    {
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("diatomic nonmetal", "#81CC60"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("noble gas", "#FFA4C3"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("alkali metal", "#FC8362"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("alkaline earth metal", "#FFDB62"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("metalloid", "#FFDB62"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("polyatomic nonmetal", "#81CC60"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("post-transition metal", "#C99FC9"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("transition metal", "#7DC1FF"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("lanthanide", "#628CFF"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("actinide", "#62E1BB"));
                    }
                    break;

                case ViewMode.Lickability:
                    {
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("Sure Probably Fine", "#00FF00"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("Maybe No a Good Idea", "#FFFF00"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("You Really Should Not", "#FF0000"));
                        this.ColorLegendItems.Add(new ColorLegendItemsModel("Please Reconsider", "#FF00FF"));
                    }
                    break;
            }
        }
    }
}
