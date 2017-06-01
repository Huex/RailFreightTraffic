using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.App
{
    public struct FbCommandArgs
    {
        public string Name;
        public List<FbCommandParameterArgs> Parameters;
        
        public FbCommandArgs(string name, List<FbCommandParameterArgs> parameters)
        {
            Parameters = parameters;
            Name = name;
        }
    }
}
