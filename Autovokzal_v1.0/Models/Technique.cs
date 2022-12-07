using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovokzal_v1._0.Models
{
    internal class Technique
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string GovNumber { get; set; }
        public string Type { get; set; }
        public int Volume { get; set; }
        public int FuelMinus { get; set; }
        public int GP { get; set; }
        public string VIN { get; set; }
    }
}
