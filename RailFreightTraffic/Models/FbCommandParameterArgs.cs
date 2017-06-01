using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.App
{
    public struct FbCommandParameterArgs
    {
        public string Name;
        public FbDbType Type;
        public object Value;

        public FbCommandParameterArgs(string name, FbDbType type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}
