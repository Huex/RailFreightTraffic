using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.Database
{
    public class Client
    {
        string Name { get; set; }
        string Address { get; set; }
        string Key { get; set; }
        ClientType ClientType { get; set; }
    }
}
