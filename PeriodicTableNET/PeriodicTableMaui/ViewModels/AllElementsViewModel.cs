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
    [QueryProperty(nameof(AllElementsViewModel.ViewMode), "viewmode")]
    public partial class AllElementsViewModel : BaseViewModel
    {
        private PeriodicTableDataEngine dataEngine;

        public ObservableCollection<ElementViewModel> Elements { get; } = new();

        public AllElementsViewModel(PeriodicTableDataEngine dataEngine)
        {
            Title = "Periodic Table of Elements";
            this.dataEngine = dataEngine;
            this.ViewMode = ViewMode.Category;
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

        public async Task<PeriodicTableDataModel> GetDataModelAsync()
        {
            PeriodicTableDataModel dataModel = await this.dataEngine.InitializeData();
            return dataModel;
        }
    }
}
