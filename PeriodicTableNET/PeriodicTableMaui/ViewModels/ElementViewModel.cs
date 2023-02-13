using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableMaui.ViewModels
{
    public partial class ElementViewModel : ObservableObject
    {
        public  PeriodicTableData.Element Element { get; set; }

        public ElementViewModel(PeriodicTableData.Element dataElement) { 
            Element = dataElement;
        }

        [ObservableProperty]
        bool isSelected;
    }
}
