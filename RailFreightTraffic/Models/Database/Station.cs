using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models
{
    public class Station
    {
        public string Key { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Territory { get; set; }
        public string HoistingDevice { get; set; }
        public string CustomsHouse { get; set; }

        public static bool operator ==(Station left, Station right)
        {
            return (left.Key == right.Key) &&
                (left.Code == right.Code) &&
                (left.Name == right.Name) &&
                (left.State == right.State) &&
                (left.Territory == right.Territory) &&
                (left.HoistingDevice == right.HoistingDevice) &&
                (left.CustomsHouse == right.CustomsHouse);
        }

        public static bool operator !=(Station left, Station right)
        {
            return (left.Key != right.Key) ||
                (left.Code != right.Code) ||
                (left.Name != right.Name) ||
                (left.State != right.State) ||
                (left.Territory != right.Territory) ||
                (left.HoistingDevice != right.HoistingDevice) ||
                (left.CustomsHouse != right.CustomsHouse);
        }
    }
}
