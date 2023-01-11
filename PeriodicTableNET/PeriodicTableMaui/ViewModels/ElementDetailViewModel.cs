using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeriodicTableData;

namespace PeriodicTableMaui.ViewModels
{
    [QueryProperty(nameof(PeriodicTableData.Element), "element")]
    public partial class ElementDetailViewModel : BaseViewModel
    {
        private IMap map;
        public ElementDetailViewModel(IMap map)
        {
            this.map = map;
        }

        [ObservableProperty]
        public PeriodicTableData.Element element;
    }
}
