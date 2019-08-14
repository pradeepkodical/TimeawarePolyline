using System.Collections.Generic;
using System.Linq;
using TimeawarePolyline.Lib.Entities;

namespace TimeawarePolyline.Lib.Utility
{
    public class DistanceServicesUtil
    {
        public double GetDistance(string encodedPolyline)
        {
            var points = new TimeawarePolylineUtil(encodedPolyline).DecodedPoints;
            var validPoints = GetValidLocations(points.ToList());
            var distance = GetDistance(validPoints);
            return distance;
        }

        private List<Location> GetValidLocations(List<Location> data)
        {
            var retList = new List<Location>();

            data.ForEach(x =>
            {
                if (x.Latitude >= -85.05115 && x.Latitude <= 85.05115 && x.Longitude >= -180 && x.Longitude <= 180)
                {
                    retList.Add(x);
                }
            });
            return retList;
        }

        private double GetDistance(List<Location> data)
        {
            var distance = 0D;
            for (var i = 0; i < data.Count - 1; i++)
            {
                distance += data[i].DistanceTo(data[i + 1]);
            }
            return distance;
        }

        public double GetDistance(double sLat, double sLng, double eLat, double eLng)
        {
            return new Location(sLat, sLng).DistanceTo(new Location(eLat, eLng));
        }
    }
}
