using System.Collections.Generic;
using TimeawarePolyline.Lib.Entities;

namespace TimeawarePolyline.Lib.Utility
{
    public class TimeawarePolylineUtil
    {
        private int index = 0;
        public Location[] DecodedPoints { get; private set; }
        public TimeawarePolylineUtil(string encodedPolyline)
        {
            DecodedPoints = GetLocations(encodedPolyline).ToArray();
        }
        private List<Location> GetLocations(string encodedPolyline)
        {
            var lat = 0;
            var lng = 0;
            var timeStamp = 0;

            var poly = new List<Location>();
            if (encodedPolyline != null)
            {
                while (index < encodedPolyline.Length)
                {
                    lat += GetPart(encodedPolyline);
                    lng += GetPart(encodedPolyline);
                    timeStamp += GetPart(encodedPolyline);

                    poly.Add(new Location((lat / 100000.0D), (lng / 100000.0D)));
                }
            }
            return poly;
        }
        private int GetPart(string polyline)
        {
            int result = 1;
            int shift = 0;

            while (true)
            {
                var polylineChar = polyline[index];
                var b = (int)(polylineChar - 63 - 1);
                index++;

                var a = b << shift;

                result += a;
                shift += 5;

                if (b < 0x1f)
                {
                    break;
                }
            }

            if ((result % 2) != 0)
            {
                return ~result >> 1;
            }
            else
            {
                return result >> 1;
            }
        }
    }
}
