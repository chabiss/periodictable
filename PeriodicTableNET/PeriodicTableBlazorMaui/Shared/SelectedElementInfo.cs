using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableBlazorMaui.Shared
{
    public class SelectedElementInfo
    {
        public SelectedElementInfo(Action callback)
        {
            SelectedElementChanged = callback;
        }
        Action SelectedElementChanged;
        public PeriodicTableData.Element? SelectedElement { get; set; }
        public void SetActiveElement(PeriodicTableData.Element element)
        {
            this.SelectedElement = element;
            this.SelectedElementChanged();
        }
    }
}
