using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.Database
{
    public class RouteSegment
    {
        public string Key { get; set; }
        public Station FirstStation { get; set; }
        public Station SecondStation { get; set; }
        public double Length { get; set; }

        public bool IsValid
        {
            get
            {
                return FirstStation != SecondStation;
            }
        }

        RouteSegment(string key, Station firstStation, Station secondStation, double length)
        {
            Key = key;
            FirstStation = firstStation;
            SecondStation = secondStation;
            Length = length;
        }

        public RouteSegment()
        {
        }
    }
}
