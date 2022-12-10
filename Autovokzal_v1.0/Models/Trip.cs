using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovokzal_v1._0.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public int StopCount { get; set; }
        public DateOnly Schedule { get; set; }
    }
}
