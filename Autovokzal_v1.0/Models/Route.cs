using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovokzal_v1._0.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string RouteStartDate { get; set; }
        public string RouteEndDate { get; set; }
        public string RouteCode { get; set; }
        public string Price { get; set; }
        public bool isClosed { get; set; }
        public string WorkingDays { get; set; }
        public bool isWEW { get; set; }
        public bool isFYear { get; set; }
    }
}
