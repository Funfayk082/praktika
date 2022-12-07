using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovokzal_v1._0.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public int? DriveLicense { get; set; }
        public string? DriverLicGetter { get; set; }
        public string? KatTS { get; set; }
        public DateTime? GetDate { get; set; }
        public DateTime? LastDate { get; set; }
    }
}
