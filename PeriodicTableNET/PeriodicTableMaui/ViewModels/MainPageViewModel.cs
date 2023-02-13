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
    public partial class MainPageViewModel : BaseViewModel
    {
        private PeriodicTableDataEngine dataEngine;

        public ObservableCollection<ElementViewModel> Elements { get; } = new();
        
        public MainPageViewModel(PeriodicTableDataEngine dataEngine)
        {
            Title = "Periodic Table of Elements";
            this.dataEngine = dataEngine;
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        bool isDetailPaneVisible;

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
            this.IsRefreshing = true;
            PeriodicTableDataModel dataModel = await this.GetDataModelAsync();
            if(dataModel != null)
            {
                this.Elements.Clear(); ;
                foreach(var element in dataModel.Elements) 
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

            if(this.SelectedElement != null)
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
    }
}
