using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTableData
{
    public class Element
    {
        public string? Name { get; set; }
        public string? Appearance { get; set; }
        public decimal? atomic_mass { get; set; }
        public decimal? Boil { get; set; }
        public string? Category { get; set; }
        public decimal? Density { get; set; }
        public string? DiscoveredBy { get; set; }
        public decimal? Melt { get; set; }
        public decimal? MolarHeat { get; set; }
        public string? NamedBy { get; set; }
        public int Number { get; set; }
        public int Period { get; set; }
        public string? Phase { get; set; }
        public string? Source { get; set; }
        public string? BohrModelImage { get; set; }
        public string? BohrModel3D { get; set; }
        public string? SpectralImg { get; set; }
        public string? Summary { get; set; }
        public string? Symbol { get; set; }
        public int xPos { get; set; }
        public int yPos { get; set; }
        public List<int>? shells { get; set; }
        public string? ElectronConfiguration { get; set; }
        public string? electron_configuration_semantic { get; set; }
        public float? electron_affinity { get; set; }
        public float? electronegativity_pauling {get; set; }
        public List<float>? ionization_energies { get; set; }
        public string? cpkHex { get; set; }
        public Image? image { get; set; }
    }
}
