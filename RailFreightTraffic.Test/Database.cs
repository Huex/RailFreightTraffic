using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RailFreightTraffic.Models.Database;
using RailFreightTraffic.Models;

namespace RailFreightTraffic.Test
{
    [TestClass]
    public class Database
    {
        [TestMethod]
        public void Route_IsValidCompound()
        {
            List<RouteSegment> segments = new List<RouteSegment>();
            segments.Add(GetPrimitiveRouteSegment(GetPrimitiveStation("Москва"), GetPrimitiveStation("Брянск")));
            segments.Add(GetPrimitiveRouteSegment(GetPrimitiveStation("Брянск"), GetPrimitiveStation("Москва")));
            segments.Add(GetPrimitiveRouteSegment(GetPrimitiveStation("Москва"), GetPrimitiveStation("Сачковичи")));

            Route route = new Route();
            route.Segments = segments;

            Assert.IsTrue(route.IsValidCompound());
        }

        public static RouteSegment GetPrimitiveRouteSegment(Station first, Station second)
        {
            RouteSegment te = new RouteSegment();
            te.SecondStation = second;
            te.FirstStation = first;
            te.Length = 0;
            te.Key = "";
            return te;
        }

        public static Station GetPrimitiveStation(string name)
        {
            Station st = new Station();
            st.Name = name;
            return st;
        }
    }
}
