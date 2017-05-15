using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFreightTraffic.Models.Database
{
    public class Route
    {
        public string Key { get; set; }
        public List<RouteSegment> Segments { get; set; }
        public Station StartStation { get; set; }
        public Station FinishStation { get; set; }

        public bool IsValidCompound()
        {
            if (Segments.Count >= 3)
            {
                RouteSegment middleSegment;
                RouteSegment leftSegment;
                RouteSegment rightSegment;
                for (int i = 1; i < Segments.Count - 1; i++)
                {
                    middleSegment = Segments.ElementAt(i);
                    leftSegment = Segments.ElementAt(i - 1);
                    rightSegment = Segments.ElementAt(i + 1);

                    if (!((((middleSegment.SecondStation == rightSegment.FirstStation) ^
                        (middleSegment.SecondStation == rightSegment.SecondStation)) &&
                        ((middleSegment.FirstStation == leftSegment.FirstStation) ^
                        (middleSegment.FirstStation == leftSegment.SecondStation))) ||
                        (((middleSegment.SecondStation == leftSegment.FirstStation) ^
                        (middleSegment.SecondStation == leftSegment.SecondStation)) &&
                        ((middleSegment.FirstStation == rightSegment.FirstStation) ^
                        (middleSegment.FirstStation == rightSegment.SecondStation)))))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                if (Segments.Count == 2)
                {
                    if ((Segments.ElementAt(0).FirstStation == Segments.ElementAt(1).FirstStation) ^
                        (Segments.ElementAt(0).FirstStation == Segments.ElementAt(1).SecondStation) ^
                        (Segments.ElementAt(0).SecondStation == Segments.ElementAt(1).FirstStation) ^
                        (Segments.ElementAt(0).SecondStation == Segments.ElementAt(1).SecondStation))
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public double Length
        {
            get
            {
                double length = 0;
                foreach(RouteSegment segment in Segments)
                {
                    length += segment.Length;
                }
                return length;
            }
        }

    }
}
