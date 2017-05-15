using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.App
{
    public class Credentials
    {
        public string Account { get; set; }
        public string Password { get; set; }

        public bool IsValid
        {
            get { return !string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password); }
        }

        public Credentials()
        {
            Account = string.Empty;
            Password = string.Empty;
        }
    }
}
