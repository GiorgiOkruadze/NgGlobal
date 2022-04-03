using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class FilterDto
    {
        public Dictionary<string, List<string>> MarksModels { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public List<string> FuelTypes { get; set; } = new List<string>();
        public List<string> Transmissions { get; set; } = new List<string>();
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public double MileageFrom { get; set; }
        public double MileageTo { get; set; }

    }
}
