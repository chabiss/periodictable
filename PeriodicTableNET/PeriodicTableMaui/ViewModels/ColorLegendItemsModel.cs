using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableMaui.ViewModels
{
    public class ColorLegendItemsModel : ObservableObject
    {
        public ColorLegendItemsModel(string description, string color)
        {
            this.Description = description;
            this.Color = Color.FromArgb(color);
        }
        public Color Color { get; set; }
        public string Description { get; set; }
    }
}
